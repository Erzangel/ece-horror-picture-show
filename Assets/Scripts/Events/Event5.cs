using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Fourth event : the Zombie rushes to the camera
public class Event5 : Event
{	
    float delta;
	float deltaStatic;
	GameObject staticScreen;
	
    public Event5(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 0.1f; // Delay before which the Event will cover the screen
		deltaStatic = 3.0f;
        staticScreen = GameObject.Find("Static");
    }

    void Update()
    {
        if(delta > 0)
        {
            //Debug.Log(deltaInit);
            delta -= Time.deltaTime;
        }
		
		
        else
        {
            if(done == true)
            {
                Debug.Log("Out Update");
                return;
            }
			
			staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha = 1F;
			staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, 0.15f);
			
			if (deltaStatic > 0)
			{
				deltaStatic -= Time.deltaTime;
			}
			else 
			{
				//staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha = 0F;
				//staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, 0);
				done = true;
				Debug.Log("Script5 Done");
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
        }
    }
}
