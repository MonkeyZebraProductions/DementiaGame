using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDropNumbers : MonoBehaviour
{
    private bool dragging = false;
    //private Color mouseOverColor = Color.blue;
    //private Color originalColor = Color.yellow;
    private float distance;
    // Start is called before the first frame update
    Vector3 worldPosition;
    void Start()
    {
        
    }

    //void OnMouseEnter()
    //{
    //    //GetComponent<Renderer>().material.color = mouseOverColor;
    //}

    //void OnMouseExit()
    //{
    //    //GetComponent<Renderer>().material.color = originalColor;
    //}

    //void OnMouseDown()
    //{
    //    distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    //    dragging = true;
    //}

    //void OnMouseUp()
    //{
    //    dragging = false;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag=="Cursor")
        {
            if(Input.GetMouseButton(0))
            {
                dragging = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Cursor")
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
            }
        }
    }
}
