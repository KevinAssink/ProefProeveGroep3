using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class ObjectMoving : MonoBehaviour
{

    public Scrolling Scrolling;
    public Vector2 movementVec;

    public GameObject movingObj;
    public GameObject endLocation;
    public Vector2 EndPoint;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = Scrolling.scrollSpeed.y + -3.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (EndPoint - (Vector2)transform.position).normalized;

        transform.position -= (Vector3)dir * speed * Time.deltaTime;

        if (movingObj.transform.position == endLocation.transform.position)
        {
            Debug.Log("Reached End!");  
            //gameObject.SetActive(false);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}