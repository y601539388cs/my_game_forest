using UnityEngine;
using System.Collections;

#if UNITY_IPHONE || UNITY_ANDROID
public class ECTouchInputCtrl : ECInputCtrl {

	public static ECTouchInputCtrl Instance  = new ECTouchInputCtrl();
	protected override bool TickTouchStates(float fDeltaTime)
	{
		TouchCount = 0;
		int iTouchCount = Input.touchCount;

		for(int i=0;i< iTouchCount;++i)
		{
			 if(TouchCount>=MaxTouchCount)
			 	break;
			 Touch touch = Input.GetTouch(i); 
			 TouchStates[TouchCount].Switch();
			 TouchStates[TouchCount].ThisTouch.touch = touch;
			 TouchStates[TouchCount].Update();

			 ++TouchCount;

		}

		if(iTouchCount>0)
		{
			IdleTime = 0;
		}
		else
		{
			IdleTime=IdleTime+fDeltaTime;
		}

		return true;
	}

}


#endif