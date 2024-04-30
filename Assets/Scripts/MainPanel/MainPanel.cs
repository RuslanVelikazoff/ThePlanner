using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button newTaskButton;
    [SerializeField] 
    private Button backButton;

    [SerializeField]
    private GameObject newTaskPanel;
    [SerializeField] 
    private GameObject mainPanel;
    
    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newTaskButton != null)
        {
            newTaskButton.onClick.RemoveAllListeners();
            newTaskButton.onClick.AddListener(() =>
            {
                OpenNewTaskPanel();
            });
        }

        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                OpenMainPanel();
            });
        }
    }

    private void OpenNewTaskPanel()
    {
        newTaskPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OpenMainPanel()
    {
        mainPanel.SetActive(true);
        backButton.gameObject.SetActive(false);
        newTaskPanel.SetActive(false);
    }
}
