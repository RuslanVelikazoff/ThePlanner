using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompletedTasks : MonoBehaviour
{
    [SerializeField]
    private Image fillImage;

    [SerializeField]
    private TextMeshProUGUI procentText;

    private List<int> indexDailyTasks;

    private float allTasks;
    private float taskCompleted;

    private void OnEnable()
    {
        indexDailyTasks = TaskData.Instance.GetDailyTasksList();
        allTasks = indexDailyTasks.Count;

        for (int i = 0; i < indexDailyTasks.Count; i++)
        {
            if (TaskData.Instance.GetTaskCompleted(i))
            {
                taskCompleted++;
            }
        }

        float procent = taskCompleted * 100 / allTasks;

        procentText.text = procent + "%";
        fillImage.fillAmount = procent / 100f;
    }
}
