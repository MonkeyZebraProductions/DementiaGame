using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public float combo;
    public TMP_Text ComboText;
    // Start is called before the first frame update
    void Start()
    {
        combo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ComboText.text = "Combo: " + combo;
        Debug.Log(combo);
    }

    public void ComboUp()
    {
        combo +=  1.0f;
        
    }
    public void ComboNull()
    {
        combo = 0.0f;
    }
}
