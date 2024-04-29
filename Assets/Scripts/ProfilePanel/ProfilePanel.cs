using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button editingProfileButton;

    [SerializeField]
    private GameObject viewingProfilePanel;
    [SerializeField] 
    private GameObject editingProfilePanel;

    private void OnEnable()
    {
        ButtonClickAction();
        OpenViewingProfilePanel();
    }

    private void OnDisable()
    {
        backButton.gameObject.SetActive(false);
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                OpenViewingProfilePanel();
            });
        }

        if (editingProfileButton != null)
        {
            editingProfileButton.onClick.RemoveAllListeners();
            editingProfileButton.onClick.AddListener(() =>
            {
                OpenEditingProfilePanel();
            });
        }
        
        
    }

    private void OpenViewingProfilePanel()
    {
        backButton.gameObject.SetActive(false);
        viewingProfilePanel.SetActive(true);
        editingProfilePanel.SetActive(false);
    }

    private void OpenEditingProfilePanel()
    {
        backButton.gameObject.SetActive(true);
        viewingProfilePanel.SetActive(false);
        editingProfilePanel.SetActive(true);
    }
}
