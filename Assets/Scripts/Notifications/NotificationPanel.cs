using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject taskPrefab;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject allTasksSpawn;
    [SerializeField] 
    private GameObject notificationTasksSpawn;
    
    private List<int> allTasksIndex = new List<int>();
    private List<GameObject> allTasksGameObjects = new List<GameObject>();

    private List<int> notificationTasksIndex = new List<int>();
    private List<GameObject> notificationTasksGameObjects = new List<GameObject>();

    private void OnEnable()
    {
        SpawnAllTasks();
        SpawnAllNotificationTasks();
    }

    public void SpawnAllTasks()
    {
        ResetAllTasks();
        
        allTasksIndex = TaskData.Instance.GetAllTasksList();

        for (int i = 0; i < allTasksIndex.Count; i++)
        {
            if (!TaskData.Instance.GetTaskNotification(allTasksIndex[i])
                && !TaskData.Instance.GetTaskCompleted(allTasksIndex[i]))
            {
                var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
                task.transform.SetParent(canvas.transform);
                task.transform.localScale = new Vector3(1, 1, 1);
                task.transform.SetParent(allTasksSpawn.transform);
                task.GetComponent<NotificationTaskPrefab>().SpawnTaskPrefab(allTasksIndex[i]);
                allTasksGameObjects.Add(task);
            }
        }
    }

    public void SpawnAllNotificationTasks()
    {
        ResetNotificationTasks();
        
        notificationTasksIndex = TaskData.Instance.GetNotificationTasksList();

        for (int i = 0; i < notificationTasksIndex.Count; i++)
        {
            if (TaskData.Instance.GetStartDate(notificationTasksIndex[i]) >= DateTime.Now)
            {
                var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
                task.transform.SetParent(canvas.transform);
                task.transform.localScale = new Vector3(1, 1, 1);
                task.transform.SetParent(notificationTasksSpawn.transform);
                task.GetComponent<NotificationTaskPrefab>().SpawnTaskPrefab(notificationTasksIndex[i]);
                notificationTasksGameObjects.Add(task);
            }
        }
    }

    private void ResetNotificationTasks()
    {
        if (notificationTasksGameObjects.Count != 0)
        {
            for (int i = 0; i < notificationTasksGameObjects.Count; i++)
            {
                Destroy(notificationTasksGameObjects[i]);
                notificationTasksGameObjects.RemoveAt(i);
                ResetNotificationTasks();
            }
        }
    }

    private void ResetAllTasks()
    {
        if (allTasksGameObjects.Count != 0)
        {
            for (int i = 0; i < allTasksGameObjects.Count; i++)
            {
                Destroy(allTasksGameObjects[i]);
                allTasksGameObjects.RemoveAt(i);
                ResetAllTasks();
            }
        }
    }


}
