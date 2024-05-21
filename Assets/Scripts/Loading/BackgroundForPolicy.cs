using UnityEngine;
using UnityEngine.UI;

public class BackgroundForPolicy : MonoBehaviour
{
    [SerializeField] 
    private Button agreeButton;

    [SerializeField] 
    private PolicyLoad policyLoad;

    private void OnEnable()
    {
        if (agreeButton != null)
        {
            agreeButton.onClick.RemoveAllListeners();
            agreeButton.onClick.AddListener(() =>
            {
                policyLoad.ConfirmPolicy();
            });
        }
    }
}
