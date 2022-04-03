using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Second event : if the previous zombie exists, destroy him when looking at him
public class Event1 : Event
{
    GameObject zombie;

    Vector3 from_object;
    
    public Event1(System.Type t) : base(t){}

    GameObject ar_cam;

    protected override void Awake()
    {
        base.Awake();
		zombie = GameObject.FindWithTag("ZombieProto");
		Debug.Log("Zombie:" + zombie);
		s_Hits = new List<ARRaycastHit>();
        ar_cam = GameObject.Find("AR Camera");
		Debug.Log(ar_cam);
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
        if(Vector3.Angle(ar_cam.transform.forward, from_object) < 30.0f)
        {
            eventManager.clearEvent<Event0>();
			done = true;
			eventManager.playEvent<Event3>();
            Debug.Log("Script1 Done");
        }
        
        
    }
	public List<ARRaycastHit> s_Hits;
}
