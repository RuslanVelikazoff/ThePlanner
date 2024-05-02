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

    private List<int> indexTasks;

    private float allTasks;
    private float taskCompleted;

    private void OnEnable()
    {
        indexTasks = TaskData.Instance.GetAllTasksList();
        allTasks = indexTasks.Count;
        taskCompleted = 0;
        
        for (int i = 0; i < indexTasks.Count; i++)
        {
            if (TaskData.Instance.GetTaskCompleted(i))
            {
                taskCompleted++;
            }
        }

        float procent = taskCompleted * 100 / allTasks;

        if (indexTasks.Count == 0)
        {
            procent = 0;
            procentText.text = procent + "%";
            fillImage.fillAmount = procent / 100f;
        }
        else
        {
            procentText.text = procent + "%";
            fillImage.fillAmount = procent / 100f;
        }
    }
}
