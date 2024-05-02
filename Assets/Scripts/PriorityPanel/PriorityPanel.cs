using UnityEngine;
using UnityEngine.UI;

public class PriorityPanel : MonoBehaviour
{
    [SerializeField] 
    private Button highPriorityButton;
    [SerializeField] 
    private Button midPriorityButton;
    [SerializeField] 
    private Button lowPriorityButton;
    
    private GameData.Priority selectedPriority;

    [SerializeField] 
    private Color activeColor;
    [SerializeField] 
    private Color inactiveColor;

    [SerializeField] 
    private PriorityScrollView scrollView;

    private void OnEnable()
    {
        selectedPriority = GameData.Priority.Null;
        scrollView.ResetTasks();
        scrollView.SpawnPrefabs(selectedPriority);
        ButtonClickAction();
        SetPriorityButtonsColor();
    }

    private void ButtonClickAction()
    {
        if (highPriorityButton != null)
        {
            highPriorityButton.onClick.RemoveAllListeners();
            highPriorityButton.onClick.AddListener(() =>
            {
                selectedPriority = GameData.Priority.High;
                scrollView.ResetTasks();
                scrollView.SpawnPrefabs(selectedPriority);
                SetPriorityButtonsColor();
            });
        }

        if (midPriorityButton != null)
        {
            midPriorityButton.onClick.RemoveAllListeners();
            midPriorityButton.onClick.AddListener(() =>
            {
                selectedPriority = GameData.Priority.Mid;
                scrollView.ResetTasks();
                scrollView.SpawnPrefabs(selectedPriority);
                SetPriorityButtonsColor();
            });
        }

        if (lowPriorityButton != null)
        {
            lowPriorityButton.onClick.RemoveAllListeners();
            lowPriorityButton.onClick.AddListener(() =>
            {
                selectedPriority = GameData.Priority.Low;
                scrollView.ResetTasks();
                scrollView.SpawnPrefabs(selectedPriority);
                SetPriorityButtonsColor();
            });
        }
    }

    private void SetPriorityButtonsColor()
    {
        switch (selectedPriority)
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
}
