using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        GameObject.Find("CouteauPPE_v1").SetActive(true);
    }
}
