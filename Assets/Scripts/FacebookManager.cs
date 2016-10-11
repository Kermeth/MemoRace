using UnityEngine;
using System.Collections;
using Facebook.Unity;
using System;
using System.Collections.Generic;

public class FacebookManager : MonoBehaviour {

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
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
        }
        else {
            Debug.Log("User cancelled login");
        }
    }



    #endregion FacebookLogin

}
