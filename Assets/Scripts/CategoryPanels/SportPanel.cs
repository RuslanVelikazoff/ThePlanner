using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SportPanel : MonoBehaviour
{
    [SerializeField]
    private Button newTaskButton;
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject newTaskPanel;
    [SerializeField] 
    private GameObject mainPanel;
    
    [SerializeField] 
    private GameObject taskPrefab;

    [SerializeField]
    private Canvas canvas;
    [SerializeField] 
    private GameObject content;

    private List<GameObject> tasks = new List<GameObject>();
    private List<int> taskIndex;

    private GameData.Category _category;

    private void OnEnable()
    {
        _category = GameData.Category.Sport;
        ResetTasks();
        SpawnPrefabs(_category);
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newTaskButton != null)
        {
            newTaskButton.onClick.RemoveAllListeners();
            newTaskButton.onClick.AddListener(() =>
            {
                newTaskPanel.SetActive(true);
                this.gameObject.SetActive(false);
                
                backButton.onClick.RemoveAllListeners();
                backButton.onClick.AddListener(() =>
                {
                    newTaskPanel.SetActive(false);
                    mainPanel.SetActive(true);
                });
            });
        }
    }

    private void SpawnPrefabs(GameData.Category category)
    {
        taskIndex = TaskData.Instance.GetCategoryTasksList(category);

        for (int i = 0; i < taskIndex.Count; i++)
        {
            var task = Instantiate(taskPrefab, transform.position, Quaternion.identity);
            task.transform.SetParent(canvas.transform);
            task.transform.localScale = new Vector3(1, 1, 1);
            task.transform.SetParent(content.transform);
            task.GetComponent<FavouriteTaskPrefab>().SpawnTaskPrefab(taskIndex[i]);
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
