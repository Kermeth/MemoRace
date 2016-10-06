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
            scoreText.text = "Score:\n" + GameManager.Instance.round;
        }
    }
}
