using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;

    private Button button;
    private UnityAction buttonAction;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void Initialize(string label, Action<(string, string)> clickEventHandler)
    {
        this.label.text = label;

        buttonAction += () => clickEventHandler((label, label));
        button.onClick.AddListener(buttonAction);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(buttonAction);
    }
}
