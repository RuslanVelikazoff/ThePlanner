using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewingProfilePanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI firstNameText;
    [SerializeField] 
    private TextMeshProUGUI lastNameText;
    [SerializeField] 
    private TextMeshProUGUI emailAddressText;
    [SerializeField]
    private TextMeshProUGUI ageText;
    [SerializeField]
    private TextMeshProUGUI activeGoalsText;
    [SerializeField] 
    private TextMeshProUGUI achievedGoalsText;

    [SerializeField] 
    private Image[] genderImages;

    [SerializeField]
    private Sprite activeGenderSprite;
    [SerializeField]
    private Sprite inactiveGenderSprite;

    private void OnEnable()
    {
        SetTexts();
        SetGenderImages();
    }

    private void SetTexts()
    {
        firstNameText.text = ProfileData.Instance.GetFirstName();
        lastNameText.text = ProfileData.Instance.GetLastName();
        emailAddressText.text = ProfileData.Instance.GetEmailAddress();
        ageText.text = ProfileData.Instance.GetAge().ToString();

        List<int> allTasks = TaskData.Instance.GetAllTasksList();
        activeGoalsText.text = allTasks.Count.ToString();

        List<int> completedTasks = TaskData.Instance.GetCompletedTasksList();
        achievedGoalsText.text = completedTasks.Count.ToString();
    }

    private void SetGenderImages()
    {
        for (int i = 0; i < genderImages.Length; i++)
        {
            if (i == ProfileData.Instance.GetActiveGenderIndex())
            {
                genderImages[i].sprite = activeGenderSprite;
            }
            else
            {
                genderImages[i].sprite = inactiveGenderSprite;
            }
        }
    }
}
