using Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputSwiping : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private List<Transform> _lanePositions;
    [SerializeField]
    private int _laneNumber;

    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;



    private void Start()
    {
        InputComponent SwipeRightTouch = InputComponent.Instance;

        SwipeRightTouch.OnTouchScreenPress.performed += BeganPress;
        SwipeRightTouch.OnTouchScreenPress.canceled += EndPress;
    }
    private void BeganPress(InputAction.CallbackContext context)
    {
        _startTouchPosition = InputComponent.Instance.OnScreenSwipeRight.ReadValue<Vector2>();
    }
    private void EndPress(InputAction.CallbackContext context)
    {
        _endTouchPosition = InputComponent.Instance.OnScreenSwipeRight.ReadValue<Vector2>();

        float TempNumber = _endTouchPosition.x - _startTouchPosition.x; 
        if( TempNumber > 0)
        {
            PreviousPos();
        }
        else
        {
            NextPos();
        }
    }
    
    private void NextPos()
    {
        _laneNumber++;
        int currentPage = _lanePositions.Count;
        int nextPage = _lanePositions[(_lanePositions.IndexOf(currentPage) + 1) % _lanePositions.Count];
        int prevPage = _lanePositions[(_lanePositions.IndexOf(currentPage) - 1 + _lanePositions.Count) % _lanePositions.Count];

        if (_lanePositions.Count >= 3)
        {
            _laneNumber = 2;
        }
    }
    private void PreviousPos()
    {
        _laneNumber--;
        if (_lanePositions.Count >= -1)
        {
            _laneNumber = 0;
        }
    }
}