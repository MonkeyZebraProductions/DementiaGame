using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlackScreenSceneSwap : MonoBehaviour
{
    public UnityEvent SceneSwap;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            SceneSwap.Invoke();
        }
    }
}
