using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button pushNotificationButton;
    [SerializeField] 
    private Button soundButton;

    [SerializeField] 
    private Button monthCalendarButton;
    [SerializeField] 
    private Button weekCalendarButton;

    [SerializeField]
    private Sprite onSprite;
    [SerializeField] 
    private Sprite offSprite;

    [SerializeField] 
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

    private int monthCalendarIndex;
    private int weekCalendarIndex;

    private void Awake()
    {
        ButtonClickAction();
    }

    private void OnEnable()
    {
        monthCalendarIndex = SettingsData.Instance.GetMonthCalendarIndex();
        weekCalendarIndex = SettingsData.Instance.GetWeekCalendarIndex();
        
        SetNotificationButtonSprite();
        SetSoundButtonSprite();
        SetCalendarButtonsColor();
    }

    private void ButtonClickAction()
    {
        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.SetVolume();
                SetSoundButtonSprite();
            });
        }

        if (pushNotificationButton != null)
        {
            pushNotificationButton.onClick.RemoveAllListeners();
            pushNotificationButton.onClick.AddListener(() =>
            {
                SettingsData.Instance.SetPushNotification();
                SetNotificationButtonSprite();
            });
        }

        if (monthCalendarButton != null)
        {
            monthCalendarButton.onClick.RemoveAllListeners();
            monthCalendarButton.onClick.AddListener(() =>
            {
                SettingsData.Instance.SetCalendarTypeIndex(monthCalendarIndex);
                SetCalendarButtonsColor();
            });
        }

        if (weekCalendarButton != null)
        {
            weekCalendarButton.onClick.RemoveAllListeners();
            weekCalendarButton.onClick.AddListener(() =>
            {
                SettingsData.Instance.SetCalendarTypeIndex(weekCalendarIndex);
                SetCalendarButtonsColor();
            });
        }
    }

    private void SetNotificationButtonSprite()
    {
        if (SettingsData.Instance.GetPushNotification())
        {
            pushNotificationButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            pushNotificationButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetSoundButtonSprite()
    {
        if (SettingsData.Instance.GetSound())
        {
            soundButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetCalendarButtonsColor()
    {
        if (SettingsData.Instance.GetCalendarTypeIndex() == monthCalendarIndex)
        {
            monthCalendarButton.GetComponent<Image>().color = activeColor;
            weekCalendarButton.GetComponent<Image>().color = inactiveColor;
        }

        if (SettingsData.Instance.GetCalendarTypeIndex() == weekCalendarIndex)
        {
            monthCalendarButton.GetComponent<Image>().color = inactiveColor;
            weekCalendarButton.GetComponent<Image>().color = activeColor;
        }
    }
}
