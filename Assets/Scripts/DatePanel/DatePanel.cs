using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DatePanel : MonoBehaviour
{
    [SerializeField] 
    private TMP_InputField inputDay;
    [SerializeField] 
    private TMP_InputField inputMonth;
    [SerializeField]
    private TMP_InputField inputYear;

    private int day;
    private int month;
    private int year;

    private DateTime date;
    
    [SerializeField] 
    private Button findButton;
    
    [SerializeField] 
    private DateScrollView scrollView;

    private void OnEnable()
    {
        ResetAll();
        scrollView.ResetTasks();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (findButton != null)
        {
            findButton.onClick.RemoveAllListeners();
            findButton.onClick.AddListener(() =>
            {
                if (CreateDate())
                {
                    scrollView.ResetTasks();
                    scrollView.SpawnPrefabs(date);
                }
            });
        }
    }

    private void ResetAll()
    {
        inputDay.text = string.Empty;
        inputMonth.text = String.Empty;
        inputYear.text = String.Empty;

        day = 0;
        month = 0;
        year = 0;
    }

    private bool CreateDate()
    {
        if (!IsEmptyString())
        {
            day = Int32.Parse(inputDay.text);
            month = Int32.Parse(inputMonth.text);
            year = Int32.Parse(inputYear.text);

            if (IsTrueDate(year, month, day))
            {
                date = new DateTime(year, month, day);
                return true;
            }
        }

        return false;
    }

    private bool IsEmptyString()
    {
        if (inputDay.text == string.Empty
            || inputMonth.text == string.Empty
            || inputYear.text == string.Empty)
        {
            return true;
        }

        return false;
    }
    
    private bool IsTrueDate(int year, int month, int day)
    {
        string dateString = $"{year}.{month}.{day}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
