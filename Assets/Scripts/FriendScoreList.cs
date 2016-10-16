using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using Facebook.MiniJSON;

public class FriendScoreList : MonoBehaviour
{

    public GameObject friendItem;

    void OnEnable()
    {
        GameManager.Instance.OnStateChanged += HandleChangeState;
    }

    void OnDisable()
    {
        GameManager.Instance.OnStateChanged -= HandleChangeState;
    }

    private void HandleChangeState(GameState newState)
    {
        if (newState == GameState.GameOver)
        {
            RequestFriendsList();
        }
    }

    public void RequestFriendsList()
    {
        GameManager.Instance.GetFacebookManager().RequestUserFriends(HandleFriendsScore);
    }

    private void HandleFriendsScore(IGraphResult result)
    {
        var dict = Json.Deserialize(result.RawResult) as Dictionary<string, object>;
        var friends = new List<object>();
        friends = (List<object>)(dict["data"]);
        if(friends.Count > 0)
        {
            foreach(object o in friends)
            {
                string friendScore;
                string friendName;
                Dictionary<string, object> friend = (Dictionary<string, object>)(o);
                Dictionary<string, object> user = (Dictionary<string, object>)(friend["user"]);
                friendScore = friend["score"].ToString();
                friendName = user["name"].ToString();
                GameObject go = Instantiate(this.friendItem);
                go.GetComponent<FriendListObject>().SetScore(friendScore);
                go.GetComponent<FriendListObject>().SetUser(friendName);
                go.transform.SetParent(this.transform);
            }
        }

    }

}
