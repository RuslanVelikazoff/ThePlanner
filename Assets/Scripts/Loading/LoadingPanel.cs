using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;
    [SerializeField]
    private Slider loaderSlider;
    public bool load = false;
    
    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
                UpdateLoaderSlider();
            }
            else
            {
                RotateScreen();
                LoadMainMenuScene();
            }
        }
    }

    private void UpdateLoaderSlider()
    {
        loaderSlider.value = timeLeft;
    }

    private void RotateScreen()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    private void LoadMainMenuScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
