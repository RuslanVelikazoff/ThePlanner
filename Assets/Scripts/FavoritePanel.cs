using System.Collections.Generic;
using UnityEngine;

public class FavoritePanel : MonoBehaviour
{
    [SerializeField] 
    private GameObject taskPrefab;

    [SerializeField]
    private Canvas canvas;
    [SerializeField] 
    private GameObject content;

    private List<GameObject> tasks = new List<GameObject>();
    private List<int> taskIndex;

    private void OnEnable()
    {
        ResetTasks();
        SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        taskIndex = TaskData.Instance.GetFavoriteTasksList();

        for (int i = 0; i < taskIndex.Count; i++)
        {
            var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
            task.transform.SetParent(canvas.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            task.transform.SetParent(content.transform);
            task.GetComponent<TaskPrefab>().SpawnTaskPrefab(taskIndex[i]);
            tasks.Add(task);
        }
    }

    private void ResetTasks()
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
