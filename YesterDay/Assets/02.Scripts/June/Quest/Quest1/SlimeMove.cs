using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlimeMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool isShow = false;
    private void OnEnable()
    {
        StartCoroutine(IDoLoate());
    }
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > 3f)
        {
            Vector3 dir = player.transform.position - transform.position;
            transform.position += dir.normalized * 2.5f * Time.deltaTime;
        }
        else
        {
            if(!isShow)
            {
                TutoIntro.instance.TutoStart();
                isShow = true;
            }
        }
    }

    IEnumerator IDoLoate()
    {
        while (true)
        {
            transform.DOLocalRotate(new Vector3(0, 180, -15f), 1f);
            yield return new WaitForSeconds(1f);
            transform.DOLocalRotate(new Vector3(0, 180, 15f), 1f);
            yield return new WaitForSeconds(1f);
        }
    }
}
