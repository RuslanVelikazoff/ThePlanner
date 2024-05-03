using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticPanel : MonoBehaviour
{
    [SerializeField] 
    private Button sportButton;
    [SerializeField] 
    private Button workButton;
    [SerializeField] 
    private Button studyButton;
    [SerializeField]
    private Button backButton;
    
    [SerializeField] 
    private GameObject sportPanel;
    [SerializeField] 
    private GameObject workPanel;
    [SerializeField] 
    private GameObject studyPanel;

    [SerializeField] private TextMeshProUGUI procentSportText;
    [SerializeField] private TextMeshProUGUI procentWorkText;
    [SerializeField] private TextMeshProUGUI procentStudyText;

    [SerializeField] private Image fillSportImage;
    [SerializeField] private Image fillWorkImage;
    [SerializeField] private Image fillStudyImage;

    private void OnEnable()
    {
        ButtonClickAction();
        
        SetStatistics(GameData.Category.Sport, fillSportImage, procentSportText);
        SetStatistics(GameData.Category.Work, fillWorkImage, procentWorkText);
        SetStatistics(GameData.Category.Study, fillStudyImage, procentStudyText);
    }

    private void ButtonClickAction()
    {
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

    private void SetStatistics(GameData.Category category, Image fillImage, TextMeshProUGUI procentText)
    {
        List<int> indexList = TaskData.Instance.GetCategoryTasksList(category);
        int taskCompleted = 0;
        int allTasks = indexList.Count;
        
        for (int i = 0; i < indexList.Count; i++)
        {
            if (TaskData.Instance.GetTaskCompleted(i))
            {
                taskCompleted++;
            }
        }

        float procent = 0;
        
        if (allTasks == 0)
        {
            procent = 0;
        }
        else
        {
            procent = taskCompleted * 100 / allTasks;
        }

        if (indexList.Count == 0)
        {
            procent = 0;
            procentText.text = procent + "%";
            fillImage.fillAmount = procent / 100f;
        }
        else
        {
            var procentRound = Math.Round(procent, 2);
            procentText.text = procentRound + "%";
            fillImage.fillAmount = procent / 100f;
        }
    }
}
