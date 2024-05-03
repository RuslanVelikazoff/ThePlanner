using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button newTaskButton;
    [SerializeField] 
    private Button allTasksButton;
    [SerializeField] 
    private Button backButton;

    [SerializeField]
    private GameObject newTaskPanel;
    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField]
    private GameObject allTasksPanel;
    
    private void OnEnable()
    {
        ButtonClickAction();
        backButton.gameObject.SetActive(false);
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

        if (allTasksButton != null)
        {
            allTasksButton.onClick.RemoveAllListeners();
            allTasksButton.onClick.AddListener(() =>
            {
                OpenAllTasksPanel();
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

    private void OpenAllTasksPanel()
    {
        allTasksPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
