using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FavouriteTaskPrefab : MonoBehaviour
{
    private int taskIndex;
    
    [SerializeField] 
    private TextMeshProUGUI taskText;
    [SerializeField] 
    private Button completeButton;
    [SerializeField] 
    private Button deleteButton;
    [SerializeField] 
    private Button favouriteButton;

    [SerializeField] 
    private Sprite favouriteSprite;
    [SerializeField] 
    private Sprite unfavouriteSprite;

    [SerializeField]
    private Sprite completedSprite;
    [SerializeField] 
    private Sprite uncompletedSprite;

    public void SpawnTaskPrefab(int index)
    {
        taskIndex = index;
        
        SetTaskText(taskIndex);
        SetCompletedSprite(taskIndex);
        SetFavouriteButtonSprite(taskIndex);
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

    private void SetFavourite(int index)
    {
        if (TaskData.Instance.GetTaskFavourite(index))
        {
            TaskData.Instance.TaskFavourite(index, false);
            SetFavouriteButtonSprite(index);
        }
        else
        {
            TaskData.Instance.TaskFavourite(index, true);
            SetFavouriteButtonSprite(index);
        }
    }

    private void SetFavouriteButtonSprite(int index)
    {
        if (TaskData.Instance.GetTaskFavourite(index))
        {
            favouriteButton.GetComponent<Image>().sprite = favouriteSprite;
        }
        else
        {
            favouriteButton.GetComponent<Image>().sprite = unfavouriteSprite;
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

        if (favouriteButton != null)
        {
            favouriteButton.onClick.RemoveAllListeners();
            favouriteButton.onClick.AddListener(() =>
            {
                SetFavourite(index);
            });
        }
    }
}
