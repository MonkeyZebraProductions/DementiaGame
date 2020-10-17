using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointandClick : MonoBehaviour
{

    private Transform playerTransform;

    public Transform startMarker,endMarker;

    Vector3 worldPosition;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    private bool startTimer;

    private bool inBox;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform= GetComponent<Transform>();
        startTimer = true;
        inBox = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && inBox==true)
        {
            if(startTimer==true)
            {
                startTime = Time.time;
                startTimer = false;
            }
            
            startMarker.position = playerTransform.position;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            endMarker.position = worldPosition;
            // Calculate the journey length.
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            playerTransform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            if (playerTransform.position == endMarker.position)
            {
                startTimer = true;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            startTimer = true;
        }

    }

    public void CanMove()
    {
        inBox = true;
        //startTimer = true;
    }

    public void CantMove()
    {
        inBox = false;
        startTimer = true;
    }
}
