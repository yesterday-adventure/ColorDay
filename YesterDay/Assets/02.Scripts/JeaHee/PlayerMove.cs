using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float speed;      // ĳ���� ������ ���ǵ�.
    [SerializeField] private float jumpSpeed;  // ĳ���� ���� ��.
    [SerializeField] private float gravity;    // ĳ���Ϳ��� �ۿ��ϴ� �߷�.

    private float originSpeed;
    private bool canDash = true;
    private Camera _cam;
    private CharacterController controller; // ���� ĳ���Ͱ� �������ִ� ĳ���� ��Ʈ�ѷ� �ݶ��̴�.
    private Vector3 MoveDir;                // ĳ������ �����̴� ����.

    void Awake()
    {
        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        _cam = Camera.main;
        originSpeed = speed;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash == true)
        {
            canDash = false;
            StartCoroutine(IncreaseSpeed());
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        speed += 5;
        yield return new WaitForSeconds(0.5f);
        speed = originSpeed;
        canDash = true;
    }

    private void Move()
    {
        transform.eulerAngles = new Vector3(0, _cam.transform.eulerAngles.y, 0);

        if (controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            MoveDir = transform.TransformDirection(MoveDir);
            MoveDir *= speed;

            // ĳ���� ����
            if (Input.GetButton("Jump"))
            {
                MoveDir.y = jumpSpeed;
            }
        }

        MoveDir.y -= gravity * Time.deltaTime; //�߷� ����

        // ĳ���� ������.
        controller.Move(MoveDir * Time.deltaTime);
    }
}

