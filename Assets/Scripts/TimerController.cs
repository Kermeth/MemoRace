using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour {

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

	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.GetCurrentGameState() == GameState.Playing)
        {
            //We can play
            if (GameManager.Instance.GetRoundState() == RoundState.Generating)
            {
                scrollBar.value += Time.deltaTime * 0.25f;
            }
            else
            {
                scrollBar.value -= Time.deltaTime * 0.25f;
            }
            
        }
	}

    public void ValueCheck(float value)
    {
        if (value >= 1)
        {
            GameManager.Instance.GetPool().PlayRound();
        }
        if(value <= 0)
        {
            GameManager.Instance.GetPool().GenerateRound();
        }
    }
}
