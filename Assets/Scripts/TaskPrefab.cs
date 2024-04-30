using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskPrefab : MonoBehaviour
{
    private int taskIndex;
    
    [SerializeField] 
    private TextMeshProUGUI taskText;
    [SerializeField] 
    private Image outlineImage;
    [SerializeField] 
    private Button completeButton;
    [SerializeField] 
    private Button deleteButton;

    [SerializeField]
    private Color lowPriorityColor;
    [SerializeField] 
    private Color midPriorityColor;
    [SerializeField] 
    private Color highPriorityColor;

    public void SpawnTaskPrefab(int index)
    {
        taskIndex = index;
        
        SetTaskText(taskIndex);
        SetOutlineColor(taskIndex);
        ButtonClickAction(taskIndex);
    }

    private void SetTaskText(int index)
    {
        taskText.text = TaskData.Instance.GetNameOfTask(index);
    }

    private void SetOutlineColor(int index)
    {
        switch (TaskData.Instance.GetPriority(index))
        {
            case GameData.Priority.Low:
                outlineImage.color = lowPriorityColor;
                break;
            case GameData.Priority.Mid:
                outlineImage.color = midPriorityColor;
                break;
            case GameData.Priority.High:
                outlineImage.color = highPriorityColor;
                break;
        }
    }

    private void ButtonClickAction(int index)
    {
        if (completeButton != null)
        {
            completeButton.onClick.RemoveAllListeners();
            completeButton.onClick.AddListener(() =>
            {
                TaskData.Instance.TaskCompleted(index);
                Destroy(this.gameObject);
            });
        }

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                TaskData.Instance.DeleteTask(index);
                Destroy(this.gameObject);
            });
        }
    }
}
