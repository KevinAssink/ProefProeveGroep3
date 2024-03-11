using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public Material ScrollingMaterial;
    public Vector2 scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScrollingMaterial.SetVector("_ScrollSpeed", scrollSpeed);       
    }
}
