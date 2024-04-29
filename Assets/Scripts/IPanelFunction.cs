using UnityEngine;

public interface IPanelFunction
{
    public void ButtonClickAction();

    public void OpenPanel(GameObject openPanel, GameObject closePanel)
    {
        openPanel.SetActive(true);
        closePanel.SetActive(false);
    }
}
