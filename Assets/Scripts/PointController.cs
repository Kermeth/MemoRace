using UnityEngine;
using UnityEngine.UI;
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

    private void Apear()
    {
        anim.SetBool("apear", true);
    }

    private void Disapear()
    {
        anim.SetBool("apear", false);
    }

    public void GetPressed()
    {
        //Check if good or bad press
    }
	
}
