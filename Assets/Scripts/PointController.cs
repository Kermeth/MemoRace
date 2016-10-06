using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PointController : MonoBehaviour {

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
            GameManager.Instance.pointsInRound.Remove(this);
        }
        else
        {
            anim.SetTrigger("BadPress");
        }
    }
	
}
