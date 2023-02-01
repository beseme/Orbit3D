using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerInteraction : MonoBehaviour
{
    // private members
    private Camera cam = null;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // cast ray from camera plain
            var cast = Camera.main.ScreenPointToRay(Input.mousePosition);
            // check if objects on Center layer have been hit, then call colour change
            var hit = Physics.Raycast(cast, LayerMask.GetMask("Center"));
            if(hit)
                GameManager.Instance.ChangeColours();
        }
    }
}
