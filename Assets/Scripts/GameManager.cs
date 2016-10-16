using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : Singleton<GameManager>{

    void Start()
    {
        ChangeGameState(GameState.Paused);
        round = 0;
    }

    #region RoundState
    public int round;
    // Event Handler
    public delegate void OnRoundStateChange(RoundState newState);
    public event OnRoundStateChange OnRoundStateChanged;
    private RoundState _roundState;
    public RoundState GetRoundState()
    {
        return _roundState;
    }
    public void ChangeRoundState(RoundState newRoundState)
    {
        if(OnRoundStateChanged!=null)OnRoundStateChanged(newRoundState);
        this._roundState = newRoundState;
    }
    #endregion RoundState

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
        if(OnStateChanged!=null)OnStateChanged(newState);
        this._currentGameState = newState;
    }
    #endregion GameState

    #region Score
    public void SaveScore(int score)
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            int highScore = PlayerPrefs.GetInt("highscore");
            if (score > highScore)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        PlayerPrefs.Save();
    }
    public int GetHighscore()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            return PlayerPrefs.GetInt("highscore");
        }
        else
        {
            return 0;
        }
    }
    #endregion Score

    #region GameManagement
    private PointPool _pool;
    public PointPool GetPool()
    {
        if (_pool == null)
        {
            _pool = FindObjectOfType<PointPool>();
        }
        return _pool;
    }

    public List<PointController> pointsInRound;
    public bool IsCorrectPoint(PointController point)
    {
        if (point.GetNumber().Equals(pointsInRound[0].GetNumber())){
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckGameOver()
    {
        if (pointsInRound.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private TimerController _timer;
    public TimerController GetTimer()
    {
        if (_timer == null)
        {
            _timer = FindObjectOfType<TimerController>();
        }
        return _timer;
    }
    public void FinishRound()
    {
        GetTimer().SetTime(0);
    }
    public void ClearGameTabletop()
    {
        if(pointsInRound!=null)pointsInRound.Clear();
        foreach(PointController point in FindObjectsOfType<PointController>())
        {
            Destroy(point.gameObject);
        }
    }
    #endregion GameManagement

    #region Facebook
    private FacebookManager _facebookManager;
    public FacebookManager GetFacebookManager()
    {
        if (_facebookManager == null)
        {
            _facebookManager = FindObjectOfType<FacebookManager>();
        }
        return _facebookManager;
    }
    #endregion Facebook

}