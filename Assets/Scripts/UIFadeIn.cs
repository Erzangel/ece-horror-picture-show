using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Source of inspiration for the code:
// https://gamedevtraum.com/en/game-development/unity-tutorials-and-solutions/how-to-fade-in-out-the-screen-in-unity/

public class UIFadeIn : MonoBehaviour
{
    [SerializeField]
	private Image blackoutImage;
	[SerializeField]
	private float blackoutOpacityChangeStep;
	private float blackoutTargetOpacity;
	
	// Start is called before the first frame update
    void Start()
    {
        blackoutTargetOpacity = 1;
    }
	
	[SerializeField]
	private float timeLeft = 2.0f;
	bool initialCondition = true;

    // Update is called once per frame
    void Update()
    {
        // If the timer is not low enough, then simply do nothing until the next call to Update().
        timeLeft -= Time.deltaTime;
		if ((timeLeft >= 0) && (initialCondition)) {
			return;
		}
		
		// After 20 seconds, we can reach this part of the code
		initialCondition = false;
		blackoutTargetOpacity = 0;
    }
	
	void FixedUpdate()
	{
		Blackout();
	}
	
	private void Blackout()
	{
		float currentOpacity = blackoutImage.color.a;
		
		if (currentOpacity < blackoutTargetOpacity)
		{
			blackoutImage.color = new Color(blackoutImage.color.r, blackoutImage.color.g, blackoutImage.color.b, blackoutImage.color.a + blackoutOpacityChangeStep);
			if (blackoutImage.color.a > blackoutTargetOpacity) 
			{
				blackoutImage.color = new Color(blackoutImage.color.r, blackoutImage.color.g, blackoutImage.color.b, blackoutTargetOpacity);
			}
		} else if (currentOpacity > blackoutTargetOpacity)
		{
			blackoutImage.color = new Color(blackoutImage.color.r, blackoutImage.color.g, blackoutImage.color.b, blackoutImage.color.a - blackoutOpacityChangeStep);
			if (blackoutImage.color.a < blackoutTargetOpacity)
			{
				blackoutImage.color = new Color(blackoutImage.color.r, blackoutImage.color.g, blackoutImage.color.b, blackoutTargetOpacity);
			}
		}
	}
	
	public void SetBlackoutOpacity(float o)
	{
		blackoutTargetOpacity = o;
	}
}
