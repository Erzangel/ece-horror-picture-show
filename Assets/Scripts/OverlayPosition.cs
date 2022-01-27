using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPosition : MonoBehaviour
{
    GameObject camera;
	float ratio;
	int height;
	int width;
	GameObject RecCorUL;
	GameObject RecCorUR;
	GameObject RecCorBL;
	GameObject RecCorBR;
	
	
	// Start is called before the first frame update
    void Start()
    {
        /*camera = GameObject.Find("AR Camera");
		if (camera) {
			if (camera.GetType().Equals(typeof(Camera))) {
				ratio = camera.aspect;
			}
		}*/
    }

    // Update is called once per frame
    void Update()
    {
        if (height != Display.systemHeight ) {
			height = Display.systemHeight;
			width = Display.systemWidth;
			// Recompute every corner position
			SetCornerPositions();
		}
    }
	
	void SetCornerPositions() {
		RecCorUL.transform
	}
}
