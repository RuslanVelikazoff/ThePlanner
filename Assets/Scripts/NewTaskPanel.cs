using System;
using System.Globalization;
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
    private Button highPriorityButton;
    [SerializeField] 
    private Button midPriorityButton;
    [SerializeField] 
    private Button lowPriorityButton;

    [SerializeField]
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

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

    private void Awake()
    {
        SetButtonsColor();
        ButtonClickAction();
    }

    private void OnEnable()
    {
        SetButtonsColor();
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

        if (highPriorityButton != null)
        {
            highPriorityButton.onClick.RemoveAllListeners();
            highPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.High;
                SetButtonsColor();
            });
        }

        if (midPriorityButton != null)
        {
            midPriorityButton.onClick.RemoveAllListeners();
            midPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.Mid;
                SetButtonsColor();
            });
        }

        if (lowPriorityButton != null)
        {
            lowPriorityButton.onClick.RemoveAllListeners();
            lowPriorityButton.onClick.AddListener(() =>
            {
                priority = GameData.Priority.Low;
                SetButtonsColor();
            });
        }
    }

    private void SetButtonsColor()
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

    private void WritingToData()
    {
        if (!IsEmtyString() && !IsPriorityNull())
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
                    Debug.Log("Write in data");
                }
            }

        }
    }

    private bool IsEmtyString()
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
}
