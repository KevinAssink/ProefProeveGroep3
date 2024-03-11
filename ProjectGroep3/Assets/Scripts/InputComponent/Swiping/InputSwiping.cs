using Input;
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
    private TMP_Text _readPages;
    [SerializeField]
    private TMP_Text _readStart;
    [SerializeField]    
    private TMP_Text _readEnd;
    [SerializeField]
    private Sprite _pageImage;
    [SerializeField]
    private List<Sprite> _numbers;
    [SerializeField] 
    private int _pageNumber;

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
        _readStart.text = _startTouchPosition.ToString();
    }
    private void EndPress(InputAction.CallbackContext context)
    {
        _endTouchPosition = InputComponent.Instance.OnScreenSwipeRight.ReadValue<Vector2>();

        _readEnd.text = _endTouchPosition.ToString();

        float TempNumber = _endTouchPosition.x - _startTouchPosition.x; 
        if( TempNumber > 0)
        {
            PreviousPage();
        }
        else
        {
            NextPage();
        }
    }
    
    private void NextPage()
    {
        _pageNumber++;
        _pageImage = _numbers[_pageNumber];

        Debug.Log("Next Page" + _pageNumber);
        _readPages.text = _pageNumber.ToString();
    }
    private void PreviousPage()
    {
        _pageNumber--;
        _pageImage = _numbers[_pageNumber];

        Debug.Log("Previous Page" + _pageNumber);
        _readPages.text = _pageNumber.ToString();
    }
}