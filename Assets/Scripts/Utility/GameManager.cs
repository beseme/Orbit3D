using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton instance
    public static GameManager Instance;
    
    // public members
    public Transform CenterObject = null;

    [HideInInspector] 
    public float SimulationSpeed = 1f;
    
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
