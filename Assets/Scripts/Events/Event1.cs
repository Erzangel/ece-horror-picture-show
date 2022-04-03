using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Second event : if the previous zombie exists, destroy him when looking at him
public class Event1 : Event
{
    GameObject zombie;
	GameObject staticScreen;
    Vector3 from_object;
	float deltaStatic;
    
    public Event1(System.Type t) : base(t){}

    GameObject ar_cam;

    protected override void Awake()
    {
        base.Awake();
		zombie = GameObject.FindWithTag("ZombieProto");
		deltaStatic = 0.3f;
		Debug.Log("Zombie:" + zombie);
		s_Hits = new List<ARRaycastHit>();
        ar_cam = GameObject.Find("AR Camera");
		Debug.Log(ar_cam);
		staticScreen = GameObject.Find("Static");
    }

    void Update()
    {
        if(done == true)
        {
            //Debug.Log("Out Update");
            return;
        }
        from_object = zombie.transform.position + new Vector3(0,1,0) - ar_cam.transform.position;
		Debug.Log(Vector3.Angle(ar_cam.transform.forward, from_object));
        if(Vector3.Angle(ar_cam.transform.forward, from_object) < 27.0f)
        {
			if (deltaStatic > 0)
			{
				deltaStatic -= Time.deltaTime;
				staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha = 0.3F;
				staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, 0.15f);
			}
			else 
			{
				staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().targetCameraAlpha = 0F;
				staticScreen.GetComponent<UnityEngine.Video.VideoPlayer>().SetDirectAudioVolume(0, 0);
				eventManager.clearEvent<Event0>();
				done = true;
				eventManager.playEvent<Event3>();
				Debug.Log("Script1 Done");
			}
        }
        
        
    }
	public List<ARRaycastHit> s_Hits;
}
