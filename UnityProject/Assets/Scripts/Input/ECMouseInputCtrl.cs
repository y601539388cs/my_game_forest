using UnityEngine;
using System.Collections;


public enum e_MouseInputID_Type
{
	Left=0,
	Right=1,
	Middle=2,
}

public class ECMouseInputCtrl : ECInputCtrl {

	public static ECMouseInputCtrl Instance  = new ECMouseInputCtrl();
	Touch2 m_mouseTouch;
	
	bool UpdateMouseTouch()
	{
		m_mouseTouch.phase = TouchPhase.Canceled;
		if(Input.GetMouseButtonDown((int)e_MouseInputID_Type.Left)|| Input.GetMouseButtonDown((int)e_MouseInputID_Type.Left))
		{
			m_mouseTouch.phase  = TouchPhase.Began;
		}else if (Input.GetMouseButtonUp((int)e_MouseInputID_Type.Left)|| Input.GetMouseButtonUp((int)e_MouseInputID_Type.Left))
		{
			m_mouseTouch.phase = TouchPhase.Ended;
		}
		else if(Input.GetMouseButton((int)e_MouseInputID_Type.Left)||Input.GetMouseButton((int)e_MouseInputID_Type.Left))
		{  
			m_mouseTouch.phase = TouchPhase.Moved;
		}

		bool bHasMouseTouch = m_mouseTouch.phase!=TouchPhase.Canceled;
		if(bHasMouseTouch)
		{
			m_mouseTouch.fingerId = -1;
			m_mouseTouch.position = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}

		return bHasMouseTouch;
	}	

	bool UpdateScrollWheel()
	{
		ScrollAxis = Input.GetAxis("Mouse ScrollWheel");
		if(ScrollAxis!=0)
		{
			return true;
		}
		return false;
	}		
	protected override bool TickInner(float fDeltaTime)
	{
		TouchCount = 0;
		bool hasTouch =  UpdateMouseTouch();

		if(hasTouch)
		{
			TouchStates[TouchCount].Switch();
			TouchStates[TouchCount].ThisTouch = m_mouseTouch;
			TouchStates[TouchCount].Update();
			++TouchCount;
			
			IdleTime = 0;
		}
		else
		{
			IdleTime=IdleTime+fDeltaTime;
		}

		UpdateScrollWheel();
		return true;
	}
}
