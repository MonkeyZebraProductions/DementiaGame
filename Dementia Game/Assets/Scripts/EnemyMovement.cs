using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class EnemyMovement : MonoBehaviour
{
    public float MaxSpeed, JitterValue;
    public float[] Jitteriness;
    private float partX, partY;
    private int i, multiplyer, index;
    public Transform LeftPos, RightPos, SpawnPoint;

    private static float resultCounter;
    private bool _isFacingLeft, canPress;
    public GameObject[] SandwichParts;
    private CapsuleCollider2D _myBox;
    public GameObject ResultScreen,OK,Good,Perfect;

    public TMP_Text QualityText;
    public UnityEvent ChangeScene;
    private string quality;
    public AudioSource soundefex;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        canPress = false;
        _myBox = SandwichParts[index].GetComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
        SandwichParts[index].transform.position = SpawnPoint.transform.position;
        partX = SpawnPoint.transform.position.x;
        partY = SpawnPoint.transform.position.y;
        Debug.Log(transform.position);
        i = 0;
        multiplyer = 1;
        ResultScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (index >= SandwichParts.Length)
        {
            QualityText.gameObject.SetActive(false);
            ResultScreen.SetActive(true);
            if (resultCounter <= 3.5f)
            {
                OK.SetActive(true);
            }
            if (resultCounter > 3.5f && resultCounter <= 5.5)
            {
                Good.SetActive(true);
            }
            if (resultCounter > 5.5f)
            {
                Perfect.SetActive(true);
            }
            //ChangeScene.Invoke();
        }

        partX += i * MaxSpeed;
        partY = Random.Range(-1 * JitterValue * Jitteriness[index], JitterValue * Jitteriness[index]);
        SandwichParts[index].transform.position = new Vector3(partX-partY, partY, 0);
        i += multiplyer;
        if (SandwichParts[index].transform.position.x > RightPos.position.x && !_isFacingLeft)
        {
            multiplyer = -1;
            i = 0;
            Flip();
        }
        if (SandwichParts[index].transform.position.x < LeftPos.position.x && _isFacingLeft)
        {
            multiplyer = 1;
            i = 0;
            Flip();
        }
        if (SandwichParts[index].transform.localPosition.x >= -0.75 && SandwichParts[index].transform.localPosition.x <= 0.75)
        {
            quality = "Perfect";

        }
        if ((SandwichParts[index].transform.localPosition.x >= -2.5 && SandwichParts[index].transform.localPosition.x < -0.75)
            || (SandwichParts[index].transform.localPosition.x > 0.75 && SandwichParts[index].transform.localPosition.x < 2.5))
        {
            quality = "Good";

        }
        if (SandwichParts[index].transform.localPosition.x >= 2.5 || SandwichParts[index].transform.localPosition.x < -2.5)
        {
            quality = "OK";

        }
        Debug.Log(resultCounter);
        if (Input.GetKey("space") && canPress == true)
        {
            soundefex.Play();
            if (SandwichParts[index].transform.localPosition.x >= -0.75 && SandwichParts[index].transform.localPosition.x <= 0.75)
            {

                resultCounter += 1.0f;
            }
            else if ((SandwichParts[index].transform.localPosition.x >= -2.5 && SandwichParts[index].transform.localPosition.x < -0.75)
                || (SandwichParts[index].transform.localPosition.x > 0.75 && SandwichParts[index].transform.localPosition.x < 2.5))
            {

                resultCounter += 0.75f;
            }
            else if (SandwichParts[index].transform.localPosition.x >= 2.5 || SandwichParts[index].transform.localPosition.x < -2.5)
            {

                resultCounter += 0.5f;
            }

            QualityText.text = quality;
            _myBox.enabled = !_myBox.enabled;
            SandwichParts[index].transform.position = SandwichParts[index].transform.position;
            index += 1;
            SandwichParts[index].SetActive(true);
            SandwichParts[index].transform.position = SpawnPoint.transform.position;
            StartCoroutine("TurnOnHitbox");
            
        }

    }
    void Flip()
    {
        //Vector3 myScale = transform.localScale;
        //myScale.x *= -1;
        //transform.localScale = myScale;
        _isFacingLeft = !_isFacingLeft;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canPress = true;
    }
    private IEnumerator TurnOnHitbox()
    {
        canPress = false;
        _myBox = SandwichParts[index].GetComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
        _myBox.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _myBox.enabled = true;
        canPress = true;
    }
}
