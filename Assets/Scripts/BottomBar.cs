using UnityEngine;
using UnityEngine.UI;

public class BottomBar : MonoBehaviour
{
    [SerializeField] 
    private Button[] buttons;

    [SerializeField] 
    private Sprite[] activeSprites;
    [SerializeField]
    private Sprite[] inactiveSprites;

    [SerializeField]
    private GameObject[] panels;
    
    private int homeIndex = 0;
    private int favoriteIndex = 1;
    private int calendarIndex = 2;
    private int settingsIndex = 3;
    private int profileIndex = 4;

    private void Awake()
    {
        OpenPanel(homeIndex);
        
        ButtonClickAction();
    }
    
    private void ButtonClickAction()
    {
        if (buttons[homeIndex] != null)
        {
            buttons[homeIndex].onClick.RemoveAllListeners();
            buttons[homeIndex].onClick.AddListener(() =>
            {
                OpenPanel(homeIndex);
            });
        }

        if (buttons[favoriteIndex] != null)
        {
            buttons[favoriteIndex].onClick.RemoveAllListeners();
            buttons[favoriteIndex].onClick.AddListener(() =>
            { 
                OpenPanel(favoriteIndex);  
            });
        }

        if (buttons[calendarIndex] != null)
        {
            buttons[calendarIndex].onClick.RemoveAllListeners();
            buttons[calendarIndex].onClick.AddListener(() =>
            {
                OpenPanel(calendarIndex);
            });
        }

        if (buttons[settingsIndex] != null)
        {
            buttons[settingsIndex].onClick.RemoveAllListeners();
            buttons[settingsIndex].onClick.AddListener(() =>
            {
                OpenPanel(settingsIndex);
            });
        }

        if (buttons[profileIndex] != null)
        {
            buttons[profileIndex].onClick.RemoveAllListeners();
            buttons[profileIndex].onClick.AddListener(() =>
            {
                OpenPanel(profileIndex);
            });
        }
    }

    private void OpenPanel(int currentIndex)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == currentIndex)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }
        
        SetButtonSprite(currentIndex);
    }

    private void SetButtonSprite(int currentIndex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == currentIndex)
            {
                buttons[i].GetComponent<Image>().sprite = activeSprites[i];
            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = inactiveSprites[i];
            }
        }
    }
}
