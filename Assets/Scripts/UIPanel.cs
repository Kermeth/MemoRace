using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Animator))]
public class UIPanel : MonoBehaviour
{

    /// <summary>
    /// The Game State where the Panel must be Shown
    /// </summary>
    public GameState gameStateToShowSelf;

    private Animator anim
    {
        get
        {
            return this.GetComponent<Animator>();
        }
    }

    #region MonoBehaviour
    public void OnEnable()
    {
        GameManager.Instance.OnStateChanged += HandleStateChange;
        //Sets the current State on Enable
        HandleStateChange(GameManager.Instance.GetCurrentGameState());
    }

    public void OnDisable()
    {
        GameManager.Instance.OnStateChanged -= HandleStateChange;
    }
    #endregion MonoBehaviour

    private void HandleStateChange(GameState newState)
    {
        if (newState.Equals(gameStateToShowSelf))
        {
            this.Show();
        }
        else
        {
            this.Hide();
        }
    }

    public void Show()
    {
        anim.SetBool("show", true);
    }

    public void Hide()
    {
        anim.SetBool("show", false);
    }

}
