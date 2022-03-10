using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Second event : if the previous zombie exists, destroy him after 2 seconds when looking at him
public class Event1 : Event
{
    
    float delta;
    GameObject zombie;
	GameObject arCamera;
    
    public Event1(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 5.0f;
        arCamera = GameObject.Find("AR Camera");
        zombie = GameObject.Find("ZombieProto");
		Debug.Log(zombie);
		s_Hits = new List<ARRaycastHit>();
    }

    void Update()
    {
        Vector3 targetDir = zombie.transform.position - arCamera.transform.position;
        float angle = Vector3.Angle(targetDir, arCamera.transform.forward);

        if (angle > 5.0f)
        {
            Debug.Log(angle);
        }
        
        /*if(delta > 0)
        {
            //Debug.Log(delta);
            delta -= Time.deltaTime;
        }*/
            
        else
        {
            if(done == true)
            {
                Debug.Log("Out Update");
                return;
            }
            
            eventManager.clearEvent<Event0>();
			done = true;
            Debug.Log("Script1 Done");
        }
        
    }
	public List<ARRaycastHit> s_Hits;
}
