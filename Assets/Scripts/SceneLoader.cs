using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    private void Awake()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        BackButtonPressed();
    }


    public void BackButtonPressed()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
    }

}