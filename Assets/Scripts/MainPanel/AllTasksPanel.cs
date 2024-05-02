using System;
using UnityEngine;
using UnityEngine.UI;

public class AllTasksPanel : MonoBehaviour
{
    [SerializeField]
    private Button categoryButton;
    [SerializeField] 
    private Button priorityButton;
    [SerializeField] 
    private Button dateButton;
    [SerializeField] 
    private Button backButton;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField] 
    private GameObject categoryPanel;
    [SerializeField]
    private GameObject priorityPanel;
    [SerializeField] 
    private GameObject datePanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (categoryButton != null)
        {
            categoryButton.onClick.RemoveAllListeners();
            categoryButton.onClick.AddListener(() =>
            {
                categoryPanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, categoryPanel);
            });
        }

        if (priorityButton != null)
        {
            priorityButton.onClick.RemoveAllListeners();
            priorityButton.onClick.AddListener(() =>
            {
                priorityPanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, priorityPanel);
            });
        }

        if (dateButton != null)
        {
            dateButton.onClick.RemoveAllListeners();
            dateButton.onClick.AddListener(() =>
            {
                datePanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, datePanel);
            });
        }
        
        BackButtonAction(mainPanel, this.gameObject);
    }

    private void BackButtonAction(GameObject openPanel, GameObject closePanel)
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                openPanel.SetActive(true);
                closePanel.SetActive(false);
            });
        }
    }
}
