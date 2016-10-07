using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

    /// <summary>
    /// Changes the State with an int to be callable from UnityEvents
    /// </summary>
    /// <param name="state">0 paused, 1 playing, 2 GameOver</param>
    public void SetGameState(int state)
    {
        GameState newState;
        switch (state)
        {
            case 0:
                newState = GameState.Paused;
                break;
            case 1:
                newState = GameState.Playing;
                break;
            case 2:
                newState = GameState.GameOver;
                break;
            default:
                newState = GameState.Paused;
                break;
        }
        GameManager.Instance.ChangeGameState(newState);
    }

    public void ReplayGame()
    {
        GameManager.Instance.round = 0;
        GameManager.Instance.ClearGameTabletop();
    }

}
