using TMPro;
using UnityEngine;

public class HeaderManager : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI title;

    public void SetTitle(string text)
    {
        title.text = text;
    }
}
