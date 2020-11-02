using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ArrowController : MonoBehaviour
{
    public float BeatTempo;
    private float songTime=50.0f;
    public UnityEvent PerfectCombo, GoodCombo,OKCombo, NullCombo;

    private bool canBePressed;

    public KeyCode keyToPress;
    private static float combo,counter,holdTimer;
    private float multiplier;
    private float smooth;
    public float RotateRate;
    public float RotateValue;
    public AudioSource Moosic;
    ///public TMP_Text ComboText,Result;
    //public GameObject ResultScreen,DancingPlayer;
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
        //transform.position+= new Vector3(0, BeatTempo * Time.deltaTime*songTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position -= new Vector3(0, BeatTempo * Time.deltaTime, 0);
        Quaternion target = Quaternion.Euler(0, 0, RotateValue);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth*smooth*smooth);
        smooth += RotateRate;
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
            Moosic.Play();
            switch (multiplier)
            {
                case 2.0f:
                    
                        PerfectCombo.Invoke();
                        
                        break;
                    
                case 1.5f:
                    
                        GoodCombo.Invoke();
                        break;
                    
                case 1.0f:
                    
                        OKCombo.Invoke();
                        break;
                    
                default:
                    
                        Debug.Log("Yandere Dev hella gay");
                        break;
            }
            gameObject.SetActive(false);
        }
       
        Debug.Log(counter);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Arrow")
        {
            canBePressed = true;
            
            
            
        }
        if (collider2D.gameObject.tag == "NullPoints")
        {
            canBePressed = false;
            
            
            NullCombo.Invoke();

        }
        
    }
    

}
