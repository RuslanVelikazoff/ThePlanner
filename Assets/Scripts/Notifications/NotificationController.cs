using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEditor;
using UnityEngine;
using static UnityEngine.iOS.NotificationServices;

public class NotificationController : MonoBehaviour
{
    [SerializeField] 
    private PushNotificator notificator;

    private void Start()
    {
        StartCoroutine(notificator.RequestAuthorization());
        CancelAllLocalNotifications();
    }

    private void OnApplicationQuit()
    {
        CreateNotifications();
    }

    private void CreateNotifications()
    {
        List<int> tasksNotification = TaskData.Instance.GetNotificationTasksList();

        for (int i = 0; i < tasksNotification.Count; i++)
        {
            if (TaskData.Instance.GetTaskNotification(tasksNotification[i])
                && TaskData.Instance.GetStartDate(tasksNotification[i]) >= DateTime.Now)
            {

                notificator.SendNotification(TaskData.Instance.GetNameOfTask(tasksNotification[i]),
                    TaskData.Instance.GetDescriptionOfTheTask(tasksNotification[i]),
                    TaskData.Instance.GetStartDate(tasksNotification[i]));
            }
        }
    }
}
