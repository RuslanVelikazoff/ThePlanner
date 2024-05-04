using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewTaskPanel : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField[] allInputFields;
    
    [SerializeField]
    private TMP_InputField inputNameOfTask;
    [SerializeField]
    private TMP_InputField inputDescriptionOfTheTask;

    [SerializeField]
    private TMP_InputField inputStartDay;
    [SerializeField]
    private TMP_InputField inputStartMonth;
    [SerializeField]
    private TMP_InputField inputStartYear;
    [SerializeField]
    private TMP_InputField inputStartHour;
    [SerializeField]
    private TMP_InputField inputStartMinute;
    
    [SerializeField]
    private TMP_InputField inputEndDay;
    [SerializeField]
    private TMP_InputField inputEndMonth;
    [SerializeField]
    private TMP_InputField inputEndYear;
    [SerializeField]
    private TMP_InputField inputEndHour;
    [SerializeField]
    private TMP_InputField inputEndMinute;

    [SerializeField] 
    private Button addTaskButton;
    [SerializeField] 
    private Button newNotificationButton;
    [SerializeField] 
    private Button backButton;

    [SerializeField] 
    private Button highPriorityButton;
    [SerializeField] 
    private Button midPriorityButton;
    [SerializeField] 
    private Button lowPriorityButton;

    [SerializeField] 
    private Button sportCategoryButton;
    [SerializeField] 
    private Button workCategoryButton;
    [SerializeField] 
    private Button studyCategoryButton;

    [SerializeField]
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

    [SerializeField] 
    private GameObject mainPanel;
    [SerializeField]
    private GameObject newNotificationPanel;

    private string nameOfTask;
    private string descriptionOfTheTask;
    
    private int startDay;
    private int startMonth;
    private int startYear;
    private int startHour;
    private int startMinute;

    private int endDay;
    private int endMonth;
    private int endYear;
    private int endHour;
    private int endMinute;

    private string startDateString;
    private string endDateString;

    private DateTime startDate;
    private DateTime endDate;

    private GameData.Priority priority;
    private GameData.Category category;

    private void Awake()
    {
        SetPriorityButtonsColor();
        SetCategoryButtonsColor();
        ButtonClickAction();
    }

    private void OnEnable()
    {
        SetPriorityButtonsColor();
    }

    private void ButtonClickAction()
    {
        if (addTaskButton != null)
        {
            addTaskButton.onClick.RemoveAllListeners();
            addTaskButton.onClick.AddListener(() =>
            {
                WritingToData();
            });
        }

        if (newNotificationButton != null)
        {
            newNotificationButton.onClick.RemoveAllListeners();
            newNotificationButton.onClick.AddListener(() =>
            {
                newNotificationPanel.SetActive(true);
                this.gameObject.SetActive(false);

                if (backButton != null)
                {
                    backButton.onClick.RemoveAllListeners();
                    backButton.onClick.AddListener(() =>
                    {
                        newNotificationPanel.SetActive(false);
                        mainPanel.SetActive(true);
                        backButton.gameObject.SetActive(false);
                    });
                }
            });
        }

        if (highPriorityButton != null)
        {
            highPriorityButton.onClick.RemoveAllListeners();
            highPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.High;
                SetPriorityButtonsColor();
            });
        }

        if (midPriorityButton != null)
        {
            midPriorityButton.onClick.RemoveAllListeners();
            midPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.Mid;
                SetPriorityButtonsColor();
            });
        }

        if (lowPriorityButton != null)
        {
            lowPriorityButton.onClick.RemoveAllListeners();
            lowPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.Low;
                SetPriorityButtonsColor();
            });
        }

        if (sportCategoryButton != null)
        {
            sportCategoryButton.onClick.RemoveAllListeners();
            sportCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.Category.Sport;
                SetCategoryButtonsColor();
            });
        }

        if (workCategoryButton != null)
        {
            workCategoryButton.onClick.RemoveAllListeners();
            workCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.Category.Work;
                SetCategoryButtonsColor();
            });
        }

        if (studyCategoryButton != null)
        {
            studyCategoryButton.onClick.RemoveAllListeners();
            studyCategoryButton.onClick.AddListener(() =>
            {
                category = GameData.Category.Study;
                SetCategoryButtonsColor();
            });
        }
    }

    private void SetPriorityButtonsColor()
    {
        switch (priority)
        {
            case GameData.Priority.Null:
                lowPriorityButton.GetComponent<Image>().color = inactiveColor;
                midPriorityButton.GetComponent<Image>().color = inactiveColor;
                highPriorityButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Priority.Low:
                lowPriorityButton.GetComponent<Image>().color = activeColor;
                midPriorityButton.GetComponent<Image>().color = inactiveColor;
                highPriorityButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Priority.Mid:
                lowPriorityButton.GetComponent<Image>().color = inactiveColor;
                midPriorityButton.GetComponent<Image>().color = activeColor;
                highPriorityButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Priority.High:
                lowPriorityButton.GetComponent<Image>().color = inactiveColor;
                midPriorityButton.GetComponent<Image>().color = inactiveColor;
                highPriorityButton.GetComponent<Image>().color = activeColor;
                break;
        }
    }

    private void SetCategoryButtonsColor()
    {
        switch (category)
        {
            case GameData.Category.Null:
                sportCategoryButton.GetComponent<Image>().color = inactiveColor;
                workCategoryButton.GetComponent<Image>().color = inactiveColor;
                studyCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Category.Sport:
                sportCategoryButton.GetComponent<Image>().color = activeColor;
                workCategoryButton.GetComponent<Image>().color = inactiveColor;
                studyCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Category.Work:
                sportCategoryButton.GetComponent<Image>().color = inactiveColor;
                workCategoryButton.GetComponent<Image>().color = activeColor;
                studyCategoryButton.GetComponent<Image>().color = inactiveColor;
                break;
            case GameData.Category.Study:
                sportCategoryButton.GetComponent<Image>().color = inactiveColor;
                workCategoryButton.GetComponent<Image>().color = inactiveColor;
                studyCategoryButton.GetComponent<Image>().color = activeColor;
                break;
        }
    }

    private void WritingToData()
    {
        if (!IsEmptyString() && !IsPriorityNull() && !IsCategoryNull())
        {
            nameOfTask = inputNameOfTask.text;
            descriptionOfTheTask = inputDescriptionOfTheTask.text;

            startDay = Int32.Parse(inputStartDay.text);
            startMonth = Int32.Parse(inputStartMonth.text);
            startYear = Int32.Parse(inputStartYear.text);
            startHour = Int32.Parse(inputStartHour.text);
            startMinute = Int32.Parse(inputStartMinute.text);

            endDay = Int32.Parse(inputEndDay.text);
            endMonth = Int32.Parse(inputEndMonth.text);
            endYear = Int32.Parse(inputEndYear.text);
            endHour = Int32.Parse(inputEndHour.text);
            endMinute = Int32.Parse(inputEndMinute.text);

            if (IsTrueDate(startYear, startMonth, startDay, startHour, startMinute)
                && IsTrueDate(endYear, endMonth, endDay, endHour, endMinute))
            {
                
                startDate = new DateTime(startYear, startMonth, startDay, startHour, startMinute, 0);
                endDate = new DateTime(endYear, endMonth, endDay, endHour, endMinute, 0);
                
                if (IsDateValidate())
                {
                    TaskData.Instance.SetNameOfTask(nameOfTask);
                    TaskData.Instance.SetDescriptionOfTheTask(descriptionOfTheTask);
                    TaskData.Instance.SetStartDate(startDate);
                    TaskData.Instance.SetEndDate(endDate);
                    TaskData.Instance.SetPriority(priority);
                    TaskData.Instance.SetCategory(category);
                    TaskData.Instance.SetTaskCompleted(false);
                    TaskData.Instance.SetFavourite(false);
                    TaskData.Instance.SetNotification(false);

                    ResetInput();
                    
                    mainPanel.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }

        }
    }

    private bool IsEmptyString()
    {
        for (int i = 0; i < allInputFields.Length; i++)
        {
            if (allInputFields[i].text == String.Empty)
            {
                return true;
                break;
            }
        }

        return false;
    }

    private bool IsTrueDate(int year, int month, int day, int hour, int minute, int second = 0)
    {
        string dateString = $"{year}.{month}.{day} {hour}:{minute}:{second}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsDateValidate()
    {
        if (startDate > DateTime.Now
            && endDate > DateTime.Now)
        {
            if (startDate < endDate)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsPriorityNull()
    {
        if (priority == GameData.Priority.Null)
        {
            return true;
        }

        return false;
    }

    private bool IsCategoryNull()
    {
        if (category == GameData.Category.Null)
        {
            return true;
        }

        return false;
    }

    private void ResetInput()
    {
        nameOfTask = string.Empty;
        inputNameOfTask.text = nameOfTask;
        descriptionOfTheTask = string.Empty;
        inputDescriptionOfTheTask.text = descriptionOfTheTask;

        startDay = 0;
        inputStartDay.text = String.Empty;
        startMonth = 0;
        inputStartMonth.text = String.Empty;
        startYear = 0;
        inputStartYear.text = String.Empty;
        startHour = 0;
        inputStartHour.text = String.Empty;
        startMinute = 0;
        inputStartMinute.text = String.Empty;

        endDay = 0;
        inputEndDay.text = String.Empty;
        endMonth = 0;
        inputEndMonth.text = String.Empty;
        endYear = 0;
        inputEndYear.text = String.Empty;
        endHour = 0;
        inputEndHour.text = String.Empty;
        endMinute = 0;
        inputEndMinute.text = String.Empty;

        startDateString = string.Empty;
        endDateString = string.Empty;
        
        priority = GameData.Priority.Null;
        category = GameData.Category.Null;
        
        SetCategoryButtonsColor();
        SetPriorityButtonsColor();
    }
}
