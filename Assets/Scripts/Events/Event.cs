using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Class representing the events that will happen during the movie. All events should inherit from this class.
public class Event : MonoBehaviour
{
    //Is the event done?
    public bool done = false;
    //Type of the component to add (example : Event0)
    public Type component;
    //Get a reference to the scripts manager
    protected ScriptedEvents eventManager;
    //Is this event currently playing?
    //public bool is_active = false;
    //Spatial reference for instanciating AR objects (sticks to the camera)
    public GameObject dummy;
    //Constructor : pass the type of the event (the component name)
    public Event(System.Type t)
    {
        component = t;
    }

    protected virtual void Awake()
    {
        eventManager = ( ScriptedEvents ) GameObject.Find("EventSystem").GetComponent<ScriptedEvents>();

        GameObject arSessionOrigin = GameObject.Find("AR Session Origin");
		m_RaycastManager = arSessionOrigin.GetComponent<ARRaycastManager>();
        m_AnchorManager = arSessionOrigin.GetComponent<ARAnchorManager>();
        m_PlaneManager = arSessionOrigin.GetComponent<ARPlaneManager>();
        m_AnchorPoints = new List<ARAnchor>();

        dummy = GameObject.Find("EventTriggerDummy");
    }
    public List<ARAnchor> m_AnchorPoints;

    public ARRaycastManager m_RaycastManager;

    public ARAnchorManager m_AnchorManager;

    public ARPlaneManager m_PlaneManager;
}
