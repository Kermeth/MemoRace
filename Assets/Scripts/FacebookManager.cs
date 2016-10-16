using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using Facebook.MiniJSON;

public class FacebookManager : MonoBehaviour {

    private string userName;
    public string GetUserName()
    {
        return userName;
    }

	// Use this for initialization
	void Awake () {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallBack, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
	}

    private void OnHideUnity(bool isUnityShown)
    {
        if (!isUnityShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }

    private void InitCallBack()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void GraphHandler(IGraphResult result)
    {
        Debug.Log(result.ToString());
        Dictionary<string,object> dict = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
        userName = dict["name"].ToString();
    }

    #region FacebookLogin
    List<string> perms = new List<string>() { "public_profile", "email", "user_friends" };

    public void FacebookLogin()
    {
        if (!FB.IsLoggedIn)
        {
            FB.LogInWithReadPermissions(perms, AuthCallback);
        }
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            FB.API("/me", HttpMethod.GET, GraphHandler);
        }
        else {
            Debug.Log("User cancelled login");
        }
    }



    #endregion FacebookLogin

    #region FacebookShare
    public void PublishScore()
    {
        if (FB.IsLoggedIn)
        {
            FB.LogInWithPublishPermissions(new List<string>() { "publish_actions" }, PublishLoginCallback);
        }
    }

    private void PublishLoginCallback(ILoginResult result)
    {
        foreach (string s in AccessToken.CurrentAccessToken.Permissions)
        {
            Debug.Log(s);
        }
        var scoreData = new Dictionary<string, string>() { { "score", GameManager.Instance.GetHighscore().ToString() } };
        FB.API("/me/scores", HttpMethod.POST, PostScoreCallback, scoreData);
    }

    private void PostScoreCallback(IGraphResult result)
    {
        //TODO SHOW CONFIRMATION
        Debug.Log(result.RawResult);
    }
    #endregion FacebookShare

    #region FacebookFriendList
    
    public void RequestUserFriends(FacebookDelegate<IGraphResult> function)
    {
        if (FB.IsLoggedIn)
        {
            FB.API(FB.AppId+"/scores", HttpMethod.GET, function);
        }
    }

    #endregion FacebookFriendList

}
