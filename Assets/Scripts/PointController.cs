using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PointController : MonoBehaviour
{

    private Animator anim
    {
        get
        {
            return this.GetComponent<Animator>();
        }
    }
    private Text number
    {
        get
        {
            return this.GetComponentInChildren<Text>();
        }
    }
    private Button button
    {
        get
        {
            return this.GetComponent<Button>();
        }
    }

    public void OnEnable()
    {
        GameManager.Instance.OnRoundStateChanged += ChangeStateHandler;
    }

    public void OnDisable()
    {
        GameManager.Instance.OnRoundStateChanged -= ChangeStateHandler;
    }

    private void ChangeStateHandler(RoundState newState)
    {
        if (newState == RoundState.Generating)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void SetNumber(int number)
    {
        this.number.text = number.ToString();
    }
    public int GetNumber()
    {
        return Int32.Parse(this.number.text);
    }

    public void Apear()
    {
        anim.SetBool("apear", true);
    }

    public void Disapear()
    {
        anim.SetBool("apear", false);
    }

    public void GetPressed()
    {
        //Check if good or bad press
        if (GameManager.Instance.IsCorrectPoint(this))
        {
            anim.SetTrigger("GoodPress");
            GameManager.Instance.pointsInRound.RemoveAt(0);
            if (GameManager.Instance.pointsInRound.Count <= 0)
            {
                GameManager.Instance.FinishRound();
            }
        }
        else
        {
            anim.SetTrigger("BadPress");
            GameManager.Instance.ChangeGameState(GameState.GameOver);
            GameManager.Instance.ChangeRoundState(RoundState.Generating);
        }
    }

}
