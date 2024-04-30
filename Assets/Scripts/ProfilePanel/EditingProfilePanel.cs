using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditingProfilePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject viewingPanel;
    
    [SerializeField] 
    private Button saveButton;

    [SerializeField] 
    private TMP_InputField inputFirstName;
    [SerializeField] 
    private TMP_InputField inputLastName;
    [SerializeField] 
    private TMP_InputField inputEmailAddress;
    [SerializeField] 
    private TMP_InputField inputAge;

    [SerializeField] 
    private Button genderMaleButton;
    [SerializeField] 
    private Button genderFemaleButton;
    [SerializeField] 
    private Button genderOtherButton;

    [SerializeField]
    private Sprite activeGenderSprite;
    [SerializeField]
    private Sprite inactiveGenderSprite;

    private int maleIndex;
    private int femaleIndex;
    private int otherIndex;

    private void Awake()
    {
        ButtonClickAction();
    }

    private void OnEnable()
    {
        maleIndex = ProfileData.Instance.GetMaleIndex();
        femaleIndex = ProfileData.Instance.GetFemaleIndex();
        otherIndex = ProfileData.Instance.GetOtherIndex();
    }

    private void ButtonClickAction()
    {
        if (saveButton != null)
        {
            saveButton.onClick.RemoveAllListeners();
            saveButton.onClick.AddListener(() =>
            {
                if (inputFirstName.text != String.Empty
                    && inputLastName.text != String.Empty
                    && inputEmailAddress.text != String.Empty
                    && inputAge.text != String.Empty
                    && ProfileData.Instance.GetActiveGenderIndex() != null)
                {
                    ProfileData.Instance.SetFirstName(inputFirstName.text);
                    ProfileData.Instance.SetLastName(inputLastName.text);
                    ProfileData.Instance.SetEmailAddress(inputEmailAddress.text);
                    ProfileData.Instance.SetAge(int.Parse(inputAge.text));
                    
                    viewingPanel.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Не все поля заполнены!");
                }
            });
        }

        if (genderMaleButton != null)
        {
            genderMaleButton.onClick.RemoveAllListeners();
            genderMaleButton.onClick.AddListener(() =>
            {
                ProfileData.Instance.SetGender(maleIndex);
                SetGenderSprite(maleIndex);
            });
        }
        
        if (genderFemaleButton != null)
        {
            genderFemaleButton.onClick.RemoveAllListeners();
            genderFemaleButton.onClick.AddListener(() =>
            {
                ProfileData.Instance.SetGender(femaleIndex);
                SetGenderSprite(femaleIndex);
            });
        }
        
        if (genderOtherButton != null)
        {
            genderOtherButton.onClick.RemoveAllListeners();
            genderOtherButton.onClick.AddListener(() =>
            {
                ProfileData.Instance.SetGender(otherIndex);
                SetGenderSprite(otherIndex);
            });
        }
    }

    private void SetGenderSprite(int currentIndex)
    {
        switch (currentIndex)
        {
            case 0:
                genderMaleButton.GetComponent<Image>().sprite = activeGenderSprite;
                genderFemaleButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                genderOtherButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                break;
            case 1:
                genderMaleButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                genderFemaleButton.GetComponent<Image>().sprite = activeGenderSprite;
                genderOtherButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                break;
            case 2:
                genderMaleButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                genderFemaleButton.GetComponent<Image>().sprite = inactiveGenderSprite;
                genderOtherButton.GetComponent<Image>().sprite = activeGenderSprite;
                break;
        }
    }
}
