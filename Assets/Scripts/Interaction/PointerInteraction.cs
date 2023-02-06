using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerInteraction : MonoBehaviour
{
    // private members
    private Camera cam = null;
    private Vector3 _scrollDirection = Vector3.zero;

    // private serialized members
    [SerializeField] 
    private float _scrollSpeed = 1f;
    [SerializeField]
    private TMP_Text _tooltip = null;
    
    void Start()
    {
        cam = Camera.main;
        _scrollDirection = (GameManager.Instance.CenterObject.position - cam.transform.position).normalized;
    }


    void Update()
    {
        // cast ray from camera plain
        var cast = Camera.main.ScreenPointToRay(Input.mousePosition);
        // check if objects on Center layer have been hit, then call colour change
        var hit = Physics.Raycast(cast, LayerMask.GetMask("Center"));
        
        if (hit)
        {
            // activate tooltip if necessary
            if(!_tooltip.gameObject.activeSelf)
                _tooltip.gameObject.SetActive(true);
            // attach tooltip to mouse position
            _tooltip.rectTransform.position = Input.mousePosition;
        }
        else
        {
            // deactivate tooltip if necessary
            if(_tooltip.gameObject.activeSelf)
                _tooltip.gameObject.SetActive(false);
        }
        
        // Call colour change when clicked
        if (Input.GetMouseButtonDown(0))
        {
            if(hit)
                GameManager.Instance.ChangeColours();
        }

        if (Input.mouseScrollDelta != Vector2.zero)
        {
            // calculate scroll amount and add to camera position
            var scrollAmount = Input.mouseScrollDelta.y * _scrollSpeed;
            cam.transform.position += _scrollDirection * scrollAmount;
        }
    }
}
