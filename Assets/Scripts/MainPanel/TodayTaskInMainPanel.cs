using System.Collections.Generic;
using UnityEngine;

public class TodayTaskInMainPanel : MonoBehaviour
{
    [SerializeField] 
    private GameObject taskPrefab;

    private List<int> taskIndex;

    private void OnEnable()
    {
        taskIndex = TaskData.Instance.GetDailyTasksList();
        
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        //TODO: fix spawn
        for (int i = 0; i < taskIndex.Count; i++)
        {
            GameObject task = Instantiate(taskPrefab);
        }
    }
}
