using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { NotStarted, Chest, Belly, Pulse }

public class FlowManager : MonoBehaviour
{
    public GameState CurrentState;
    public GameState PreviousState;

    public event Action<GameState, GameState> OnStateChanged;

    public void SetState(GameState newState)
    {
        if (newState == CurrentState) return;

        PreviousState = CurrentState;
        CurrentState = newState;

        OnStateChanged?.Invoke(CurrentState, PreviousState);
    }
}
