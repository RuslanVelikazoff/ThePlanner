using UnityEngine;
using UnityEngine.UI;

public class BackgroundForOther : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button forwardButton;

    [SerializeField] 
    private PolicyLoad policyLoad;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                policyLoad.GoBack();
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                policyLoad.GoForward();
            });
        }
    }
}
