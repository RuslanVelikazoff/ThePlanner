using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] allPanels;

    private void OnEnable()
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            allPanels[i].SetActive(false);
        }
    }
}
