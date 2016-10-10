using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimerController : MonoBehaviour
{

    private Text message
    {
        get
        {
            return this.GetComponentInChildren<Text>();
        }
    }
    private Slider scrollBar
    {
        get
        {
            return this.GetComponentInChildren<Slider>();
        }
    }

    private RoundState state;

    public void OnEnable()
    {
        GameManager.Instance.OnRoundStateChanged += ChangeRoundStateHandler;
    }

    public void OnDisable()
    {
        GameManager.Instance.OnRoundStateChanged -= ChangeRoundStateHandler;
    }

    private void ChangeRoundStateHandler(RoundState newState)
    {
        if (newState == RoundState.Generating)
        {

        }
    }

    public void SetTime(float newTime)
    {
        scrollBar.value = newTime;
    }



    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentGameState() == GameState.Playing)
        {
            //We can play
            if (GameManager.Instance.GetRoundState() == RoundState.Generating)
            {
                scrollBar.value += Time.deltaTime * 0.25f;
            }
            else
            {
                scrollBar.value -= Time.deltaTime * (0.5f/GameManager.Instance.round);
            }

        }
    }

    public void ValueCheck(float value)
    {
        if (value >= 1)
        {
            GameManager.Instance.GetPool().PlayRound();
            this.message.text = "Click where the points were";
        }
        if (value <= 0)
        {
            if (GameManager.Instance.CheckGameOver())
            {
                GameManager.Instance.ChangeGameState(GameState.GameOver);
                GameManager.Instance.ChangeRoundState(RoundState.Generating);
            }
            else
            {
                GameManager.Instance.GetPool().GenerateRound();
                this.message.text = "Memorize the points";
            }

        }
    }
}
