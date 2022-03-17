using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Third event : we toss a cup around
public class Event2 : Event
{
    
    float delta;
    GameObject cup;
	GameObject arCamera;
	float xSpeed = 0.1f;
	float ySpeed = 0.1f;
	float zAcceleration = 0.01f;
    
    public Event2(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 5.0f;
        arCamera = GameObject.Find("AR Camera");
		cup = Instantiate(Resources.Load<GameObject>("Tasse"));
		cup.transform.position = arCamera.transform.position + new Vector3(-0.5f, 0.2f, 0);
		Rigidbody cupRigidBody = cup.AddComponent<Rigidbody>();
		cupRigidBody.mass = 5;
		BoxCollider cupBoxCollider = cup.AddComponent<BoxCollider>();
        instances.Add(cup);
		if (cup == null)
        {
            Debug.Log("Error instantiating cup.");
        }
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
                Debug.Log("Out Update");
                return;
            }
            
			cup.transform.position = cup.transform.position + new Vector3(Time.deltaTime * xSpeed, Time.deltaTime * ySpeed, Time.deltaTime*Time.deltaTime * zAcceleration);
			
            

            //eventManager.playEvent(typeof(Event1));
            done = true;
            Debug.Log("Script2 Done");
			//eventManager.playEvent<Event1>();
        }
        
        
    }
}
