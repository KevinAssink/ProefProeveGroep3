using InputNameSpace;
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
    //[SerializeField]
    //private List<int> _lanePositions;
    
    //private int _laneNumber;
    private Vector2 _startTouchPosition;
    private Vector2 _endTouchPosition;

    [SerializeField]
    private List<Transform> _lanes = new();
    //[SerializeField]
    //private GameObject _player;
    private Transform _currentLane;

    private void Awake()
    {
        //_lanes = new();
        _currentLane = _lanes[1];
    }

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

        if ( TempNumber > 0)
        {
            //PreviousPos();
            SwitchLane(true);
        }
        else
        {
            //NextPos();
            SwitchLane(false);
        }
    }
    private void SwitchLane(bool _moveToRight)
    {
        int _currentIndex = _lanes.IndexOf(_currentLane);

        if (_moveToRight && _currentIndex + 1 <= 3)
        {
            _currentLane = _lanes[_currentIndex + 1];
            MoveToLane();
        }
        else if (!_moveToRight && _currentIndex - 1 >= 0)
        {
            _currentLane = _lanes[_currentIndex - 1];
            MoveToLane();
        }
    }
    private void MoveToLane()
    {
        //om smooth te maken, doen met lerp of slerp
        transform.position = _currentLane.position;
    }

    /*private void NextPos()
    {
        int currentPos = _lanePositions.Count;
        int nexPos = _lanePositions[(_lanePositions.IndexOf(currentPos) + 1) % _lanePositions.Count];     
        
        _laneNumber++;
        if (_lanePositions.Count >= 3)
        {
            _laneNumber = 2;
        }
    }*/
    /*private void PreviousPos()
    {
        /*int currentPos = _lanePositions.Count;
        int prevPos = _lanePositions[(_lanePositions.IndexOf(currentPos) - 1 + _lanePositions.Count) % _lanePositions.Count];

        _laneNumber--;
        if (_lanePositions.Count >= -1)
        {
            _laneNumber = 0;
        }
    }*/
}