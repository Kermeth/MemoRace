using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Facebook.Unity;
using System;

public class FacebookLoginButton : MonoBehaviour {

    private Button button
    {
        get
        {
            return this.GetComponent<Button>();
        }
    }

	// Use this for initialization
	void Update () {
        if (FB.IsLoggedIn)
        {
            string user= GameManager.Instance.GetFacebookManager().GetUserName();
            button.interactable = false;
            button.GetComponentInChildren<Text>().text = "Welcome " + user;
        }
	}
}
