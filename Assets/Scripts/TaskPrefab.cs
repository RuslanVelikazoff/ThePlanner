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

    [SerializeField] 
    private Sprite completedSprite;
    [SerializeField]
    private Sprite uncompletedSprite;

    public void SpawnTaskPrefab(int index)
    {
        taskIndex = index;
        
        SetCompletedSprite(taskIndex);
        SetTaskText(taskIndex);
        SetOutlineColor(taskIndex);
        ButtonClickAction(taskIndex);
    }

    private void SetCompletedSprite(int index)
    {
        if (TaskData.Instance.GetTaskCompleted(index))
        {
            completeButton.GetComponent<Image>().sprite = completedSprite;
        }
        else
        {
            completeButton.GetComponent<Image>().sprite = uncompletedSprite;
        }
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
                SetCompletedSprite(index);
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
