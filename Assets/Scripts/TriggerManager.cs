using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public string curEventID = "init";
    private void OnTriggerEnter()
    {
        switch(curEventID)
        {
            case "ZombieRun":
            {
                Event4 found = Object.FindObjectOfType<Event4>();
                found.endTrigger = true;
            }
            break;
        }
    }
}
