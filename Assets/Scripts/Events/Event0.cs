using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//First event : wait 5 seconds then instantiate zombie which makes a sound
public class Event0 : Event
{
    
    float delta = 5.0f;
    Object prefab;
    
    public Event0(System.Type t) : base(t){}

    void Awake()
    {
        prefab = Resources.Load("ZombieProto");
    }

    void Update()
    {
        delta -= Time.deltaTime;
        if(delta > 0 || done == true)
            return;
        
        Ray dummyRay = new Ray(dummy.transform.position, Vector3.down);
		
        if (AR.m_RaycastManager.Raycast(dummyRay, AR.s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = AR.s_Hits[0].pose;
            var hitTrackableId = AR.s_Hits[0].trackableId;
            var hitPlane = AR.m_PlaneManager.GetPlane(hitTrackableId);

            // This attaches an anchor to the area on the plane corresponding to the raycast hit,
            // and afterwards instantiates an instance of your chosen prefab at that point.
            // This prefab instance is parented to the anchor to make sure the position of the prefab is consistent
            // with the anchor, since an anchor attached to an ARPlane will be updated automatically by the ARAnchorManager as the ARPlane's exact position is refined.
            var anchor = AR.m_AnchorManager.AttachAnchor(hitPlane, hitPose);
            Instantiate(prefab, anchor.transform);

            if (anchor == null)
            {
                Debug.Log("Error creating anchor.");
            }
            else
            {
                // Stores the anchor so that it may be removed later.
                AR.m_AnchorPoints.Add(anchor);
            }

            eventManager.nextEvent();
            done = true;
            is_active = false;
        }
    }
}
