using System;
using UnityEngine;
using UnityEngine.UI;

public class CategoryPanel : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button sportButton;
    [SerializeField] private Button workButton;
    [SerializeField] private Button studyButton;

    [SerializeField] private GameObject allTasksPanel;
    [SerializeField] private GameObject sportPanel;
    [SerializeField] private GameObject workPanel;
    [SerializeField] private GameObject studyPanel;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (sportButton != null)
        {
            sportButton.onClick.RemoveAllListeners();
            sportButton.onClick.AddListener(() =>
            {
                sportPanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, sportPanel);
            });
        }

        if (workButton != null)
        {
            workButton.onClick.RemoveAllListeners();
            workButton.onClick.AddListener(() =>
            {
                workPanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, workPanel);
            });
        }

        if (studyButton != null)
        {
            studyButton.onClick.RemoveAllListeners();
            studyButton.onClick.AddListener(() =>
            {
                studyPanel.SetActive(true);
                this.gameObject.SetActive(false);
                BackButtonAction(this.gameObject, studyPanel);
            });
        }
        
        BackButtonAction(allTasksPanel, this.gameObject);
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
