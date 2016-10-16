using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIScore : MonoBehaviour
{

    private Text scoreText
    {
        get
        {
            return this.GetComponent<Text>();
        }
    }

    public void OnEnable()
    {
        GameManager.Instance.OnStateChanged += HandleStateChange;
    }

    public void OnDisable()
    {
        GameManager.Instance.OnStateChanged -= HandleStateChange;
    }

    private void HandleStateChange(GameState newState)
    {
        if (newState == GameState.GameOver)
        {
            int score = GameManager.Instance.round;
            GameManager.Instance.SaveScore(score);
            scoreText.text = "Score:\n" + score+ "\n Highscore:\n" + GameManager.Instance.GetHighscore();
            
        }
    }
}
