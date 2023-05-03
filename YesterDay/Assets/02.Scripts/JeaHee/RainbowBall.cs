using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RainbowBall : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(2);
            transform.DOMoveY(transform.position.y + 2f, 3f).SetEase(Ease.Linear);
            Sequence seq = DOTween.Sequence()
            .Append(transform.DORotate(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)), 1)).SetEase(Ease.Linear)
            .Append(transform.DORotate(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)), 1)).SetEase(Ease.Linear)
            .Append(transform.DORotate(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)), 1)).SetEase(Ease.Linear)
            .Append(transform.DORotate(new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f)), 1)).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                GameObject obj = Instantiate(effect);
                obj.transform.position = transform.position;
                Destroy(obj, 3);
            })
            .AppendInterval(3)
            .AppendCallback(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
