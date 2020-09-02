using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdSource : MonoBehaviour, IUnityAdsListener
{
    private string placement = "rewardedVideo";
    private string gameID = "3797097";

    IEnumerator Start()
    {
        Advertisement.Initialize(gameID, false);

        while(!Advertisement.IsReady(placement))
        {
            yield return null;
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(placement);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            // Пользователь просмотрел рекламу
            PlayerStats.Instance.Coins += 10;
        }
        else if(showResult == ShowResult.Skipped)
        {
            // Пользователь пропустил рекламу
            Debug.Log("Ad not viewed");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }
}
