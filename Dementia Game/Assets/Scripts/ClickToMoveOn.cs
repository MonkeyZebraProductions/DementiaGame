using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickToMoveOn : MonoBehaviour
{
    public UnityEvent MoveOn;
    Color m_MouseOverColor = Color.red;
    Color m_OriginalColor;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        m_OriginalColor= spriteRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        spriteRenderer.material.color= m_MouseOverColor;

    }
    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        spriteRenderer.material.color = m_OriginalColor;
    }
    void OnMouseDown()
    {
        MoveOn.Invoke();
    }

}
