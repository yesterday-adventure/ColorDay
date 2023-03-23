using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    private float speed;      // ĳ���� ������ ���ǵ�.
    private float jumpSpeed;  // ĳ���� ���� ��.
    private float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.
    private float rotateSpeed = 50f;
    private float _dashTime = 0.2f;
    private float _dashSpeed = 200f;
    private float mouseX = 0;

    private bool _canDash = true;
    private bool _isDash = false;

    private Camera _cam;
    private CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.

    void Awake()
    {
        //Time.timeScale = 0.3f;
        speed = 6.0f;
        jumpSpeed = 8.0f;
        gravity = 20.0f;

        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        _cam = Camera.main;
    }

    void Update()
    {
        //    mouseX += Input.GetAxis("Mouse X");
        //    transform.eulerAngles = new Vector3(0, mouseX, 0);

        //float h = Input.GetAxisRaw("Horizontal");
        //transform.rotation = Quaternion.Euler(0, h * Time.deltaTime * rotateSpeed, 0) * transform.rotation;
        // ���� ĳ���Ͱ� ���� �ִ°�?
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Dash();
        Move();
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _canDash = false;
            _isDash = true;
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        while (Time.time < startTime + _dashTime)
        {
            transform.Translate(transform.forward * _dashSpeed * Time.deltaTime, Space.World);
            yield return null;
        }
        _isDash = false;
        yield return new WaitForSeconds(0.5f);
        _canDash = true;
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, _cam.transform.eulerAngles.y, 0);

        if (_isDash == false)
        {
            if (controller.isGrounded)
            {
                MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                MoveDir = transform.TransformDirection(MoveDir);
                MoveDir *= speed;
                // ĳ���� ����
                if (Input.GetButton("Jump"))
                    MoveDir.y = jumpSpeed;
            }
        }

        MoveDir.y -= gravity * Time.deltaTime; //�߷� ����

        // ĳ���� ������.
        controller.Move(MoveDir * Time.deltaTime);
    }
}

