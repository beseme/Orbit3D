using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimescaleSlider : MonoBehaviour
{
    // private members
    private Slider _slider = null;
    // private serialized members
    [SerializeField]
    private TMP_Text _descriptionText = null;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        // Initiate Slider
        _slider.value = .5f;
        _descriptionText.text = "Simulation Speed: 100%";
    }

    public void SetSimulationSpeed(float percentage)
    {
        // Set simulation speed multiplier
        GameManager.Instance.SimulationSpeed = percentage * 2;
        // Update description text
        _descriptionText.text = "Simulation Speed: " + Mathf.RoundToInt(percentage * 200).ToString() + "%";
    }
}
