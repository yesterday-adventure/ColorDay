using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSecondQuest : MonoBehaviour
{
    public static TutoSecondQuest Instance;
    public int cnt = 0;
    [SerializeField] TestEnemy testEnemy;
    [SerializeField] Transform[] points;
    bool qStart = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TutoSecondQuest is Multiple");

    }
    private void Update()
    {
        if(cnt == 10)
        {
            Destroy(gameObject);
            StageTuto.Instance.ClearQuest();
        }
    }
    private void FixedUpdate()
    {
        if(StageTuto.Instance.idx == 1)
        {
            if(!qStart)
                FirstSpawn();
            qStart = true;
            StageTuto.Instance.processTmp.text = $"<{cnt} / 10>";
        }
    }

    private void FirstSpawn()
    {
        foreach(var p in points)
        {
            TestEnemy t = Instantiate(testEnemy, p);
        }
    }
}
