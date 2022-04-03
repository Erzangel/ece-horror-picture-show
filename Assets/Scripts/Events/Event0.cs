using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//First event : wait 5 seconds then instantiate zombie which makes a sound
public class Event0 : Event
{
    
    float delta;
    
    public Event0(System.Type t) : base(t){}

    protected override void Awake()
    {
        base.Awake();
        delta = 5.0f;
		prefabs.Add(Resources.Load<GameObject>("ZombieProto"));
		prefabs[0].name = "ZombieProto";
		prefabs[0].tag = "ZombieProto";
		Debug.Log("Zombie tag in Event0:" + prefabs[0].tag);
		Debug.Log(prefabs[0]);
		s_Hits = new List<ARRaycastHit>();
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
                //Debug.Log("Out Update Event0");
                return;
            }
            
            Ray dummyRay = new Ray(dummy.transform.position, Vector3.down);
			//Debug.Log(dummyRay);
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
                if(m_RaycastManager.Raycast(
                    new Ray(anchor.transform.position, new Vector3(prefabs[0].transform.position.x, prefabs[0].transform.position.y, prefabs[0].transform.position.z)),
                    s_Hits,
                    TrackableType.PlaneWithinPolygon
                    ))
                    anchor.transform.position = new Vector3(anchor.transform.position.x-s_Hits[0].distance, anchor.transform.position.y, anchor.transform.position.z);
                    
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

                //eventManager.playEvent(typeof(Event1));
                done = true;
                Debug.Log("Script0 Done");
				eventManager.playEvent<Event1>();
            }
            else
            {
                Debug.Log("Ray problem");
            }
        }
        
    }
	public List<ARRaycastHit> s_Hits;
}
