using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FriendListObject : MonoBehaviour {

    private Text user, score;

	// Use this for initialization
	void OnEnable () {
	    foreach(Text text in GetComponentsInChildren<Text>())
        {
            if (text.name.Equals("Name"))
            {
                user = text;
            }
            if (text.name.Equals("Score"))
            {
                score = text;
            }
        }
	}
	
    public void SetUser(string username)
    {
        user.text = username;
    }

    public void SetScore(string score)
    {
        this.score.text = score;
    }
}
