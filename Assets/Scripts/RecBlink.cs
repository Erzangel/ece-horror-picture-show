using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecBlink : MonoBehaviour
{
    [SerializeField]
	private RawImage img;
	
	private float timeLeft = 1.0f;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
		if (timeLeft >= 0) {
			return;
		}
		
		timeLeft = 1.0f;
		
		if (img.color.a == 0)
		{
			img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
		} else
		{
			img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
		}
    }
}
