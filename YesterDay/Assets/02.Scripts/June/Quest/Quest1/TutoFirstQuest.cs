using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFirstQuest : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(StageTuto.Instance.idx == 0)
            {
                StageTuto.Instance.ClearQuest();
                GameObject obj = GetComponentInParent<ParticleSystem>().gameObject;
                Destroy(obj);
            }
        }
    }
}
