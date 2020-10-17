using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance; 
    private Vector2 target;
    private Vector2 position;
    private float speed = 0.5f;

    private void Start()
    {
        target = new Vector2(0.0f, 0.0f);
        position = gameObject.transform.position;
    }


    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {

        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}

