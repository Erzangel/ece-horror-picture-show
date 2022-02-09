using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Event Manager : maestro that coordinates the order and chronology of all the scripted events.
public class ScriptedEvents : MonoBehaviour
{
    //List containing all the scripted events
    //public List<Event> event_list = new List<Event>();
    //Which event is active?
    //public int active_event = 0;
    float delta_sync = 7.0f;
    bool started = false;

    void Awake()
    {
        //Add list of events
        //Event zero : after 5 seconds, instanciate prefab "ZombieProto" which makes a sound
        //event_list.Add(new Event0(typeof(Event0)));
        
    }
    void Update()
    {
        //Buffer time to let the AR app create the AR surfaces. Then start the first event.
        if(delta_sync > 0)
            delta_sync -= Time.deltaTime;
        else if(started == false)
        {
            started = true;
            playEvent(typeof(Event0));
        }
    }

    //Get to next event
    /*public void nextEvent()
    {
        active_event++;
    }*/
    //Start event, instanciate its script
    public void playEvent(System.Type t)
    {
        //event_list[active_event].is_active = true;
        gameObject.AddComponent(t); //(event_list[index].component);
    }
    //End event, clear its instance
    public void clearEvent(System.Type t)
    {
        Destroy(GetComponent(t));
        //event_list[active_event].is_active = false;
    }
}
