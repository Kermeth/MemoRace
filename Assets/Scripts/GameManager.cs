using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>{

    void Start()
    {
        ChangeGameState(GameState.Paused);
    }

    #region GameState
    // Event Handler
    public delegate void OnStateChange(GameState newState);
    public event OnStateChange OnStateChanged;
    private GameState _currentGameState;
    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
    public void ChangeGameState(GameState newState)
    {
        //Raise Event
        OnStateChanged(newState);
        this._currentGameState = newState;
    }
    #endregion GameState

}