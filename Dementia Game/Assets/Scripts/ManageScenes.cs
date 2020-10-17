using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    private static int buildIndex = 0;
    private string[] scenePath;
    

    public void Loading()
    {
        buildIndex += 1;
        SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
        Debug.Log(buildIndex);
    }
}
