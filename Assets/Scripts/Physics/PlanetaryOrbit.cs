using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetaryOrbit : MonoBehaviour
{
    // public members
    public Transform CenterOfMass = null;

    // private serialized members
    [SerializeField]
    private float _speed = 1;

    #region Orbit
    
    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        this.transform.RotateAround(CenterOfMass.position, Vector3.up,
            _speed * Time.deltaTime);
    }
    
    #endregion
}
