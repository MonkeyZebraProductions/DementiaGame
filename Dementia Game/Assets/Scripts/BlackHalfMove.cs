using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHalfMove : MonoBehaviour
{
    public Transform StartPos, EndPos;
    private bool swap;
    // Start is called before the first frame update
    void Start()
    {
        swap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(swap==true)
        {
            transform.position = StartPos.position;
        }
        else
        {
            transform.position = EndPos.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag=="Player")
        {
            swap = !swap;
        }
        
    }
}
