using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ArrowController : MonoBehaviour
{
    public float BeatTempo,Arrows;
    

    private bool canBePressed;

    public KeyCode keyToPress;
    public UnityEvent LoadScene;
    private static float combo,counter,holdTimer;
    private float multiplier;

    public TMP_Text ComboText;
    //private BoxCollider2D boxCollider2D;
    //private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        multiplier = 1.0f;
        BeatTempo /= 60;
        canBePressed = false;
        combo = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, BeatTempo * Time.deltaTime, 0);
        ComboText.text = "Combo: " + combo;
        if (transform.position.y>=-5.25 && transform.position.y <= -4.25)
        {
            multiplier = 2.0f;
        }
        if (transform.position.y > -4.25 && transform.position.y <= -3.25 || transform.position.y >= -6.25 && transform.position.y < -5.25)
        {
            multiplier = 1.5f;
        }
        
        if (transform.position.y > -3.25 || transform.position.y < -6.25)
        {
            multiplier = 1.0f;
        }
        if (Input.GetKeyDown(keyToPress) && canBePressed==true)
        {
            //ComboUp.Invoke();
            gameObject.SetActive(false);
            combo += multiplier;
            
        }
        if(counter==Arrows-1)
        {
            LoadScene.Invoke();
        }
        Debug.Log(counter);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Arrow")
        {
            canBePressed = true;
            Debug.Log("yee");
            counter += 1;
        }
        if (collider2D.gameObject.tag == "NullPoints")
        {
            canBePressed = false;
            combo = 0.0f;
            
            //ComboNull.Invoke();

        }
        
    }
    

}
