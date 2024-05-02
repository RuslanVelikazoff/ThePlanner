using System;
using System.Collections.Generic;
using UnityEngine;

public class PriorityScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject taskPrefab;

    [SerializeField]
    private Canvas canvas;

    private List<GameObject> tasks = new List<GameObject>();
    private List<int> taskIndex;

    public void SpawnPrefabs(GameData.Priority priority)
    {
        taskIndex = TaskData.Instance.GetPriorityTasksList(priority);

        for (int i = 0; i < taskIndex.Count; i++)
        {
            var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
            task.transform.SetParent(canvas.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            task.transform.SetParent(this.gameObject.transform);
            task.GetComponent<TaskPrefab>().SpawnTaskPrefab(taskIndex[i]);
            tasks.Add(task);
        }
    }

    public void ResetTasks()
    {
        Debug.Log(tasks.Count);
        if (tasks.Count != 0)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Destroy(tasks[i]);
                tasks.RemoveAt(i);
                ResetTasks();
            }
        }
    }
}
