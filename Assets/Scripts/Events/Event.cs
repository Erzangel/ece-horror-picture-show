using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//Class representing the events that will happen during the movie. All events should inherit from this class.
public class Event : MonoBehaviour
{
    //Is the event done?
    public bool done = false;
    //Type of the component to add (example : Event0)
    public Type component;
    //Get all relevant data for AR through this. Prototype : in final version, replace this with its own code.
    protected AnchorOnWall AR = ( AnchorOnWall ) GameObject.Find("AR Session Origin").GetComponent<AnchorOnWall>();
    //Get a reference to the scripts manager
    protected ScriptedEvents eventManager = ( ScriptedEvents ) GameObject.Find("EventSystem").GetComponent<ScriptedEvents>();
    //Is this event currently playing?
    public bool is_active = false;
    //Spatial reference for instanciating AR objects (sticks to the camera)
    public GameObject dummy = GameObject.Find("EventTriggerDummy");
    //Constructor : pass the type of the event (the component name)
    public Event(System.Type t)
    {
        component = t;
    }

}
