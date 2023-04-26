using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoFivethQuest : MonoBehaviour
{
    public static TutoFivethQuest Instance;
    public int cnt = 0;
    [SerializeField] TestEnemy testEnemy;
    [SerializeField] Transform[] points;
    bool qStart = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("TutoFivethQuest is Multiple");

    }
    private void Update()
    {
        if (cnt == 10)
        {
            Destroy(gameObject);
            StageTuto.Instance.ClearQuest();
        }
    }
    private void FixedUpdate()
    {
        if (StageTuto.Instance.idx == 4)
        {
            if (!qStart)
                FirstSpawn();
            qStart = true;
            StageTuto.Instance.processTmp.text = $"<{cnt} / 10>";
        }
    }

    private void FirstSpawn()
    {
        foreach (var p in points)
        {
            TestEnemy t = Instantiate(testEnemy, p);
        }
    }
}
