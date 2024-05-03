using System;
using System.Globalization;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    [SerializeField]
    private HeaderManager headerManager;
    [SerializeField] 
    private BodyManager bodyManager;
    [SerializeField] 
    private CalendarScrollView scrollView;

    private DateTime targetDateTime;
    private CultureInfo cultureInfo;

    private void Start()
    {
        targetDateTime = DateTime.Now;
        cultureInfo = new CultureInfo("en-EU");
        Refresh(targetDateTime.Year, targetDateTime.Month);
    }

    public void OnGoToPreviousOrNextMonthButtonClicked(string param)
    {
        targetDateTime = targetDateTime.AddMonths(param == "Prev" ? -1 : 1);
        Refresh(targetDateTime.Year, targetDateTime.Month);
    }

    private void Refresh(int year, int month)
    {
        headerManager.SetTitle($"{year} {cultureInfo.DateTimeFormat.GetMonthName(month)}");
        bodyManager.Initialize(year, month, OnButtonClicked);
    }

    private void OnButtonClicked((string day, string legend) param)
    {
        int day = Int32.Parse(param.day);
        DateTime selectedDate = new DateTime(targetDateTime.Year, targetDateTime.Month, day);
        scrollView.SpawnPrefabs(selectedDate);
    }
}
