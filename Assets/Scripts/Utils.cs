using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

    /// <summary>
    /// Changes the State with an int to be callable from UnityEvents
    /// </summary>
    /// <param name="state">0 paused, 1 playing</param>
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
            default:
                newState = GameState.Paused;
                break;
        }
        GameManager.Instance.ChangeGameState(newState);
    }

}
