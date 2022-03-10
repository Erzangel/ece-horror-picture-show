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
    
    public Event2(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 5.0f;
        arCamera = GameObject.Find("AR Camera");
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
            
           

            // This attaches an anchor to the area on the plane corresponding to the raycast hit,
            // and afterwards instantiates an instance of your chosen prefab at that point.
            // This prefab instance is parented to the anchor to make sure the position of the prefab is consistent
            // with the anchor, since an anchor attached to an ARPlane will be updated automatically by the ARAnchorManager as the ARPlane's exact position is refined.
            cup = Instantiate(Resources.Load<GameObject>("tasseCassePPE"));
			Rigidbody cupRigidBody = cup.AddComponent<Rigidbody>();
			cupRigidBody.mass = 5;
			BoxCollider cupBoxCollider = cup.AddComponent<BoxCollider>();
            instances.Add(cup);
            if (cup == null)
            {
                Debug.Log("Error instantiating cup.");
            }
            else
            {
                // Stores the anchor so that it may be removed later.
                //m_AnchorPoints.Add(anchor);
            }

            //eventManager.playEvent(typeof(Event1));
            done = true;
            Debug.Log("Script2 Done");
			//eventManager.playEvent<Event1>();
        }
        
        
    }
}
