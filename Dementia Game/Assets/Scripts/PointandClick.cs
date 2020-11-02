using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointandClick : MonoBehaviour
{

    private Transform playerTransform;

    public Transform startMarker,endMarker;

    Vector3 worldPosition;
    public float positiveYBounds, negativeYBounds, positiveXBounds, negativeXBounds;
    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength,displacement;

    private bool startTimer,isfacingleft;

    private bool canMoveAgain;

    public GameObject EndPoint;
    public GameObject sprite;

    private Animator animator;
    
    private AudioSource footsteps;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform= GetComponent<Transform>();
        startTimer = true;
        canMoveAgain = false;
        startMarker.position = playerTransform.position;
        endMarker.position = playerTransform.position;
        
        animator = gameObject.GetComponentInChildren<Animator>();
        
        footsteps = gameObject.GetComponent<AudioSource>();
        isfacingleft = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetPos();
            StartCoroutine(ResetBounds());
        }
       // canMoveAgain = false;
        
        MoveChar();
       

            //if (Input.GetMouseButtonUp(0))
            //{
            //    startTimer = true;
            //}

    }
    void SetPos()
    {
        if (startTimer == true || playerTransform.position!=endMarker.position)
        {
            startTime = Time.time;
            startTimer = false;
            animator.SetBool("Walking", true);
            footsteps.Play();
        }
        
        startMarker.position = playerTransform.position;
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        endMarker.position = worldPosition;
        EndPoint.transform.position = endMarker.position;
        Debug.Log(isfacingleft);
        if (endMarker.position.y < positiveYBounds || endMarker.position.y > negativeYBounds 
            || endMarker.position.x < positiveXBounds || endMarker.position.x > negativeXBounds)
        {
            canMoveAgain = true;
            
        }
    }
    void MoveChar()
    {
        
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        displacement = transform.position.x - endMarker.position.x;
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        playerTransform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        if(displacement<0.0f && isfacingleft==false)
        {
            Flip();
        }
        else if(displacement>0.0f && isfacingleft == true)
        {
            Flip();
        }
        if (playerTransform.position == endMarker.position)
        {
            startTimer = true;
            animator.SetBool("Walking", false);
            footsteps.Stop();
        }
        if (playerTransform.position.y >= positiveYBounds && canMoveAgain ==false)
        {
            Vector3 tempEnd;
            tempEnd = new Vector3(endMarker.position.x, positiveYBounds, 0);
            endMarker.position = tempEnd;
        }
        if (playerTransform.position.y <= negativeYBounds && canMoveAgain == false)
        {
            Vector3 tempEnd;
            tempEnd = new Vector3(endMarker.position.x, negativeYBounds, 0);
            endMarker.position = tempEnd;
        }
        if (playerTransform.position.x <= negativeXBounds && canMoveAgain == false)
        {
            Vector3 tempEnd;
            tempEnd = new Vector3(negativeXBounds, endMarker.position.y, 0);
            endMarker.position = tempEnd;
        }
        if (playerTransform.position.x >= positiveXBounds && canMoveAgain == false)
        {
            Vector3 tempEnd;
            tempEnd = new Vector3(positiveXBounds, endMarker.position.y, 0);
            endMarker.position = tempEnd;
        }
    }

    void Flip()
    {
        Vector3 myScale = sprite.transform.localScale;
        myScale.x *= -1;
        sprite.transform.localScale = myScale;
        isfacingleft = !isfacingleft;
    }

    IEnumerator ResetBounds()
    {
        yield return new WaitForSeconds(0.1f);
        canMoveAgain = false;
    }
    //public void CanMove()
    //{
    //    inBox = true;
    //    //startTimer = true;
    //}

    //public void CantMove()
    //{
    //    inBox = false;
    //    startTimer = true;
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag=="Wall")
    //    {
    //        CantMove();
    //    }
    //}
}
