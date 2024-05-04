using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.iOS;

public class PushNotificator : MonoBehaviour
{
    public IEnumerator RequestAuthorization()
    {
        using var req = new AuthorizationRequest(
            AuthorizationOption.Alert | AuthorizationOption.Badge,
            true);

        while (!req.IsFinished)
        {
            yield return null;
        }
    }

    public void SendNotification(string title, string body, DateTime timeNotification)
    {
        var calendarTrigger = new iOSNotificationCalendarTrigger()
        {
            Year = timeNotification.Year,
            Month = timeNotification.Month,
            Day = timeNotification.Day,
            Hour = timeNotification.Hour,
            Minute = timeNotification.Minute,
            Second = timeNotification.Second,
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Identifier = "notification",
            Title = title,
            Body = body,
            Subtitle = "", //Zamenit mb
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "default_category",
            ThreadIdentifier = "thread1",
            Trigger = calendarTrigger
        };
        
        iOSNotificationCenter.ScheduleNotification(notification);
    }
}
