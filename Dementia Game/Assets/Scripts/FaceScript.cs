using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{
    private Rigidbody2D _myRb;
    public GameObject me;
    public GameObject Face1;
    public GameObject Face2;
    public GameObject Face3;
    public GameObject Face4;
    public GameObject myNextObj;
    public BoxCollider2D myBox;

    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {

    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Face1" && me.tag == "FirstFace")
        {
            me.SetActive(false);
            myNextObj.SetActive(true);
        }
        if (collision.tag == "Face2" && me.tag == "SecondFace")
        {
            me.SetActive(false);
            myNextObj.SetActive(true);
        }
        if (collision.tag == "Face3" && me.tag == "ThirdFace")
        {
            me.SetActive(false);
            myNextObj.SetActive(true);
        }
        if (collision.tag == "Face4" && me.tag == "FourthFace")
        {
            me.SetActive(false);
            myNextObj.SetActive(true);
        }


    }
}
