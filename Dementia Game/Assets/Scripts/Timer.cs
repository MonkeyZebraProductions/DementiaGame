using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    void Start()
    {
       
    }

    public TMP_Text TimerText;
    public float TimeRemaining = 45f;
    public GameObject goodfinishbox;

    private void Update()
    {
        TimeRemaining -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(TimeRemaining / 60);
        float seconds = Mathf.FloorToInt(TimeRemaining % 60);
        TimerText.text = "Time Remaining: " + minutes + ":" + seconds;

        if(TimeRemaining <= 0f)
        {
            goodfinishbox.SetActive(true);
            TimerText.gameObject.SetActive(false);
        }
    }

    /*
    IEnumerator reloadTimer(float reloadTimeInSeconds)
    {
        float counter = 0f;

        while (counter < reloadTimeInSeconds)
        {
            counter += Time.deltaTime;
            timerText.text = "Timer:"+counter;
            yield return null;
            Debug.Log(counter);
        }

        //Load new Scene
        SceneManager.LoadScene(0);
    }
    */
}
