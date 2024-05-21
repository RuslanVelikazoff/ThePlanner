using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyLoad : MonoBehaviour
{
    public GameObject webViewGameObject;
    public LoadingPanel loader;
    public UniWebView policyWebView;
    public string policyUrl;
    public GameObject noConnectionScreen;
    public GameObject loadingScreen;
    public GameObject backgroundForPolicy, backgroundForOther;


    private bool pageLoadCompleteHandled = false;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        CheckInitialConnection();
    }

    private void CheckInitialConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowNoConnectionScreen();
        }
        else
        {
            NavigateBasedOnPolicyCheck();
        }
    }

    private void ShowNoConnectionScreen()
    {
        loadingScreen.SetActive(false);
        noConnectionScreen.SetActive(true);
    }

    private IEnumerator CheckConnectionAndProceed()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            ShowNoConnectionScreen();
            yield return new WaitForSeconds(5f);
        }

        noConnectionScreen.SetActive(false);
        DisplayPolicyPage();
    }

    private void DisplayPolicyPage()
    {
        policyWebView.OnPageFinished += OnPolicyPageLoadComplete;
        policyWebView.Load(policyUrl);
    }

    private void OnPolicyPageLoadComplete(UniWebView webView, int statusCode, string currentUrl)
    {
        if (pageLoadCompleteHandled) return;

        UpdateUIBasedOnUrl(currentUrl);
        policyWebView.Show();

        if (policyUrl != currentUrl)
        {
            Destroy(gameObject);
        }

        pageLoadCompleteHandled = true;
    }

    private void UpdateUIBasedOnUrl(string currentUrl)
    {
        bool isPolicyPage = currentUrl == policyUrl;
        GameObject activeBackground = isPolicyPage ? backgroundForPolicy : backgroundForOther;
        activeBackground.SetActive(true);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyCheck", isPolicyPage ? "Confirmed" : currentUrl);
    }

    public void ConfirmPolicy()
    {
        webViewGameObject.SetActive(false);
        backgroundForPolicy.SetActive(false);
        NavigateBasedOnPolicyCheck();
        policyWebView.gameObject.SetActive(false);
    }

    private void NavigateBasedOnPolicyCheck()
    {
        string policyCheck = PlayerPrefs.GetString("PolicyCheck", "");

        if (string.IsNullOrEmpty(policyCheck))
        {
            StartCoroutine(CheckConnectionAndProceed());
        }
        else
        {
            if (policyCheck == "Confirmed")
            {
                loadingScreen.SetActive(true);
                loader.load = true;
            }
            else
            {
                policyWebView.Load(policyCheck);
                policyWebView.Show();
                backgroundForOther.SetActive(true);
            }
        }
    }
    
    public void GoBack()
    {
        if (policyWebView.CanGoBack) 
        {
            policyWebView.GoBack();
        }
    }

    public void GoForward()
    {
        if (policyWebView.CanGoForward)
        {
            policyWebView.GoForward();
        }
    }
}
