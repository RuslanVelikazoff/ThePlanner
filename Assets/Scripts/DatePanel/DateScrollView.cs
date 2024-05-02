using System;
using System.Collections.Generic;
using UnityEngine;

public class DateScrollView : MonoBehaviour
{
    [SerializeField] 
    private GameObject taskPrefab;

    [SerializeField]
    private Canvas canvas;

    private List<GameObject> tasks = new List<GameObject>();
    private List<int> taskIndex;

    public void SpawnPrefabs(DateTime date)
    {
        taskIndex = TaskData.Instance.GetDateTaskList(date);

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
