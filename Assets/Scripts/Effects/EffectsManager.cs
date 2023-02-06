using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectsManager : MonoBehaviour
{
    // private members
    private Camera _cam = null;
    private Sequence _runningSequence = null;
   
    // private serialized members
    [SerializeField] 
    private float _punchAmount = 1f;
    [SerializeField] 
    private float _punchDuration = .5f;

    private void Start()
    {
        _cam = Camera.main;
        GameManager.Instance.CenterClicked += _doGlitchEffect;
    }

    private void OnDestroy()
    {
        GameManager.Instance.CenterClicked -= _doGlitchEffect;
    }

    private void _doGlitchEffect()
    {
        _runningSequence?.Kill(true);
        _runningSequence
            .Append(_cam.transform.DOPunchRotation(Vector3.forward * _punchAmount, _punchDuration, 1));
    }
}
