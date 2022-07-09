using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsListener
{
    public static AdManager Instance;
    GameOverHandler gameOverHandler;
    [SerializeField] bool TestMode = true;
    #if UNITY_ANDROID
        string gameId = "4833612";
    #elif UNITY_IOS
        string gameId = "4833612";
    #endif

    

    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId,TestMode);
        }
    }
    public  void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error{message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished :
                gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped :
                // To be implemented when Ads Skipped
                break;
            case ShowResult.Failed :
                Debug.Log("Ads Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ad Ready");
    }
}
