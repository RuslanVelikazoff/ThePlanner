using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationTaskPrefab : MonoBehaviour
{
    private int taskIndex;

    [SerializeField] 
    private Button addNotificationButton;
    
    [SerializeField] 
    private TextMeshProUGUI taskText;
    [SerializeField] 
    private TextMeshProUGUI dateText;

    private NotificationPanel notificationPanel;

    private void OnEnable()
    {
        notificationPanel = FindObjectOfType<NotificationPanel>();
    }

    public void SpawnTaskPrefab(int index)
    {
        taskIndex = index;
        
        SetTaskText(taskIndex);
        ButtonClickAction(taskIndex);
    }

    private void SetTaskText(int index)
    {
        taskText.text = TaskData.Instance.GetNameOfTask(index);

        DateTime notificationDate = TaskData.Instance.GetStartDate(index);
        string notificationDateString = $"{notificationDate.Day}" +
                                        $".{notificationDate.Month}" +
                                        $".{notificationDate.Year} / " +
                                        $"{notificationDate.Hour}:" +
                                        $"{notificationDate.Minute}";

        dateText.text = notificationDateString;
    }
    

    private void ButtonClickAction(int index)
    {
        if (addNotificationButton != null)
        {
            addNotificationButton.onClick.RemoveAllListeners();
            addNotificationButton.onClick.AddListener(() =>
            {
                if (TaskData.Instance.GetTaskNotification(index))
                {
                    TaskData.Instance.TaskNotification(index, false);
                    notificationPanel.SpawnAllTasks();
                    notificationPanel.SpawnAllNotificationTasks();
                }
                else
                {
                    TaskData.Instance.TaskNotification(index, true);
                    notificationPanel.SpawnAllTasks();
                    notificationPanel.SpawnAllNotificationTasks();
                }
            });
        }
    }
}
