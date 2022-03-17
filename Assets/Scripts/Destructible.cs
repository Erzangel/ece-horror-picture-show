using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    //Shattered version of the model
    public GameObject DestroyedVersion;
    //Destruction sound
    public AudioClip clip;

    public void OnCollisionEnter() 
    {
        Instantiate(DestroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
