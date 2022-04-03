using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Fourth event : the Zombie rushes to the camera
public class Event4 : Event
{
    bool instantiated = false;
    float deltaInit;
	float deltaEnd;
    GameObject soundEmitter;
	GameObject arCamera;
	Vector3 targetPosition;
	GameObject zombie;
	public List<ARRaycastHit> s_Hits;
	
    
    public Event4(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        deltaInit = 3.0f; // Delay before which the Event will attempt to spawn the Zombie
		deltaEnd = 1.5f;
        arCamera = GameObject.Find("AR Camera"); // Get AR Camera from Scene
		s_Hits = new List<ARRaycastHit>(); // List for Raycast hits upon instantiating
		prefabs.Add(Resources.Load<GameObject>("ZombieEnding")); // Prefab to use for the ZombieSpawn
		prefabs[0].name = "ZombieProto";
		prefabs[0].tag = "ZombieProto";
		AudioClip sound = (AudioClip) Resources.Load("Sprinting");
		//Attach the sound
		prefabs[0].AddComponent<AudioSource>();
		prefabs[0].GetComponent<AudioSource>().clip = sound;
    }

    void Update()
    {
        if(deltaInit > 0)
        {
            //Debug.Log(deltaInit);
            deltaInit -= Time.deltaTime;
        }
		
		
        else
        {
            if(done == true)
            {
                Debug.Log("Out Update");
                return;
            }
			
			if (instantiated == false)
			{
				Ray dummyRay = new Ray(dummy.transform.position, Vector3.down);
				Debug.Log(dummyRay);
				if (m_RaycastManager.Raycast(
					dummyRay, 
					s_Hits, 
					TrackableType.PlaneWithinPolygon))
				{
					Debug.Log("Ray success");
					// Raycast hits are sorted by distance, so the first one
					// will be the closest hit.
					var hitPose = s_Hits[0].pose;
					var hitTrackableId = s_Hits[0].trackableId;
					var hitPlane = m_PlaneManager.GetPlane(hitTrackableId);

					// This attaches an anchor to the area on the plane corresponding to the raycast hit,
					// and afterwards instantiates an instance of your chosen prefab at that point.
					// This prefab instance is parented to the anchor to make sure the position of the prefab is consistent
					// with the anchor, since an anchor attached to an ARPlane will be updated automatically by the ARAnchorManager as the ARPlane's exact position is refined.
					var anchor = m_AnchorManager.AttachAnchor(hitPlane, hitPose);
					instances.Add(Instantiate(prefabs[0], anchor.transform));

					if (anchor == null)
					{
						Debug.Log("Error creating anchor.");
					}
					else
					{
						// Stores the anchor so that it may be removed later.
						m_AnchorPoints.Add(anchor);
					}
					zombie = GameObject.FindWithTag("ZombieProto");
					instantiated = true;
					Debug.Log("Event4 ZombieSpawn Done");
					zombie.GetComponent<AudioSource>().Play();
				}
			}
			else
			{
				targetPosition = new Vector3( arCamera.transform.position.x, 
											  zombie.transform.position.y, 
											  arCamera.transform.position.z );
				zombie.transform.LookAt(targetPosition);
				// handle 2nd delta or look condition before running
				// zombie.GetComponent<AudioSource>().Play();
				
				if (deltaEnd > 0)
				{
					deltaEnd -= Time.deltaTime;
					transform.Translate(Vector3.forward * 1.5f*Time.deltaTime);
				}
				else
				{
					done = true;
					Debug.Log("Script4 Done");
					eventManager.playEvent<Event5>();
				}
				
				
			}
           
        }
    }
}
