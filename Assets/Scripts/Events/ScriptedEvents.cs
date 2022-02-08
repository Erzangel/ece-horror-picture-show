using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Event Manager : maestro that coordinates the order and chronology of all the scripted events.
public class ScriptedEvents : MonoBehaviour
{
    //List containing all the scripted events
    public List<Event> event_list = new List<Event>();
    //Which event is active?
    public int active_event = 0;

    void Awake()
    {
        //Add list of events
        //Event zero : after 5 seconds, instanciate prefab "ZombieProto" which makes a sound
        event_list.Add(new Event0(typeof(Event0)));
    }
    void Update()
    {
        //Play the active event, set its active state to true
        if(event_list[active_event].is_active == false)
        {
            playEvent(active_event);
        }
        //Clear the event instance (component) if it has just finished
        else if(event_list[active_event].is_active == true && event_list[active_event].done == true)
        {
            clearEvent(active_event);
            nextEvent();
        }
            
    }

    //Get to next event
    public void nextEvent()
    {
        active_event++;
    }
    //Start event
    public void playEvent(int index)
    {
        event_list[active_event].is_active = true;
        gameObject.AddComponent(event_list[index].component);
    }
    //End event, clear its instance
    public void clearEvent(int index)
    {
        Destroy(GetComponent(event_list[index].component));
        event_list[active_event].is_active = false;
    }
}
