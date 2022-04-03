using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Third event : we toss a cup around
public class Event3 : Event
{
    
    float delta;
    GameObject soundEmitter;
	GameObject arCamera;
	
	
    
    public Event3(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 5.0f;
        arCamera = GameObject.Find("AR Camera");
		soundEmitter = new GameObject("SoundEmitter");
		soundEmitter.transform.position = arCamera.transform.position + new Vector3(-3f, -3f, 0);
		AudioClip sound = (AudioClip) Resources.Load("Sprinting");
		//Play the sound
		soundEmitter.AddComponent<AudioSource>();
		soundEmitter.GetComponent<AudioSource>().clip = sound;
    }

    void Update()
    {
        if(delta > 0)
        {
            //Debug.Log(delta);
            delta -= Time.deltaTime;
        }
		
		
        else
        {
            if(done == true)
            {
                //Debug.Log("Out Update");
                return;
            }
            
			soundEmitter.GetComponent<AudioSource>().Play();
           

            done = true;
            Debug.Log("Script3 Done");
			eventManager.playEvent<Event2>();
        }
        
        
    }
}
