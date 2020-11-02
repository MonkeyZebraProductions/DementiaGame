using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    public float PerfectCombo, GoodCombo, OKCombo,MusicStartTime;

    private static float combo;
    public int Arrows;
    private static int counter;
    public GameObject ResultScreen, DancingPlayer,Good,Great,OK;
    public TMP_Text ComboText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        ResultScreen.SetActive(false);
        combo = 0.0f;
        //sfx = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == Arrows)
        {
            ComboText.gameObject.SetActive(false);
            DancingPlayer.SetActive(false);
            ResultScreen.SetActive(true);
            
            if(combo<50)
            {
                OK.SetActive(true);
            }
            else if(combo>100)
            {
                Great.SetActive(true);
            }
            else
            {
                Good.SetActive(true);
            }
        }
        ComboText.text = "Combo: " + combo;
        
    }

    public void OKComboUp()
    {
        combo +=  OKCombo;
        counter += 1;
       
    }
    public void GoodComboUp()
    {
        combo += GoodCombo;
        counter += 1;
       
    }
    public void PerfectComboUp()
    {
        combo += PerfectCombo;
        counter += 1;
        
    }
    public void ComboNull()
    {
        combo = 0.0f;
        counter += 1;
    }

   
}
