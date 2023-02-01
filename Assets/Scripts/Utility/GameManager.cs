using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton instance
    public static GameManager Instance;
    
    // public members
    public delegate void GameEvent();
    public event GameEvent CenterClicked;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeColours()
    {
        CenterClicked?.Invoke();
    }
}
