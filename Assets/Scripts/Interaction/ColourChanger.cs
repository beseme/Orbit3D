using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    // private serialized members
    [SerializeField]
    private Color _defaultColour = Color.white;
    [SerializeField]
    private Color _clickedColour = Color.red;

    [SerializeField]
    private float _fadeDuration = .75f;
    
    // private members
    private MeshRenderer _renderer = null;

    private Tween _runningTween = null;

    private bool _clicked = false;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    void Start()
    {
        _renderer.material.color = _defaultColour;
        // register event action
        GameManager.Instance.CenterClicked += _changeColour;
    }

    private void OnDestroy()
    {
        // unregister event action
        GameManager.Instance.CenterClicked -= _changeColour;
    }
    
    private void _changeColour()
    {
        _clicked = !_clicked;
        // get target colour
        var targetColour = _clicked ? _clickedColour : _defaultColour;
        // start colour change
        _runningTween?.Kill(true);
        _runningTween = _renderer.material.DOColor(targetColour, _fadeDuration);
    }
}
