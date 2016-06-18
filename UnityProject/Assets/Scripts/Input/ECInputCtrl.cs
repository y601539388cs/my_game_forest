using UnityEngine;
using System.Collections;


public struct MouseTouch
{
	public int fingerId;
	public Vector2 position;
	public Vector2 deltaPosition;
	public float deltaTime;
	public int tapCount;
	public TouchPhase phase;
	
}


public struct Touch2
{	
#if UNITY_IPHONE || UNITY_ANDROID
	public Touch touch;
#else
	public MouseTouch touch;
#endif

	public int fingerId { get{return touch.fingerId;} set{touch.fingerId=value;}}
	public Vector2 position { get{return touch.position;}set{touch.position=value;}}
	public Vector2 deltaPosition {get {return touch.deltaPosition;}set{touch.deltaPosition=value;}}
	public float deltaTime {get {return touch.deltaTime;}set{touch.deltaTime=value;}}
	public int tapCount {get {return touch.tapCount;}set{touch.tapCount=value;}}
	public TouchPhase phase{ get{return touch.phase;}set{touch.phase=value;}}
}


public class TouchState
{
	public Touch2 ThisTouch;
	public Touch2 LastTouch;
	public Touch2 BeginTouch;
	public Touch2 EndTouch;


	public bool HasMoved  = false;

	public void Switch()
	{
		Touch2 temp = LastTouch;
		LastTouch = ThisTouch;
		ThisTouch=temp;
	}

	public bool IsPhaseChanged()
	{
		return ThisTouch.phase == TouchPhase.Began || ThisTouch.phase != LastTouch.phase;
	}

	public bool Update()
	{
		switch(ThisTouch.phase)
		{
			case TouchPhase.Began:
				BeginTouch = ThisTouch;
				HasMoved = false;
				break;
			case TouchPhase.Moved:
				if(!HasMoved && !IsInScope(BeginTouch.position,ThisTouch.position))
					HasMoved=true;
				break;
			case TouchPhase.Ended:
				EndTouch = ThisTouch;
				break;
		}	


		if(ThisTouch.phase != TouchPhase.Began && LastTouch.phase == TouchPhase.Ended)
		{
			BeginTouch = ThisTouch;
			HasMoved = false;
		}
		return true;
	}


	protected bool IsInScope(Vector2 ptOtigin, Vector2 ptPos)
	{
		return Vector2.Distance(ptOtigin,ptPos) <=10f;
	}

}



public class ECInputCtrl  {
	public const int MaxTouchCount = 5;

	protected int m_iTouchCount;

	public int TouchCount
	{
		get{ return m_iTouchCount;}
		set{m_iTouchCount=(value<=MaxTouchCount)?value:MaxTouchCount;}
	}

	public TouchState []TouchStates = new TouchState[MaxTouchCount];
	public ECInputFilter CurFilter;
	public e_InputFilter_Type CurFilterType 
	{ 
		get{return (CurFilter == null)? e_InputFilter_Type.INPUTFILTER_TYPE_INVALID : CurFilter.Type;}

	} 

	public bool DisableCurFilter;

	public float IdleTime = 0;

	public bool SetCurFilter(e_InputFilter_Type eInputType)
	{
		if(CurFilterType== eInputType)
		{
			return true;
		}

		CurFilter=CreateFilter(eInputType);
		return CurFilter!=null;
	}

	public virtual bool Init()
	{
	
		for(int i=0;i<MaxTouchCount;++i)
		{
			TouchStates[i] = new TouchState();
		}

		SetCurFilter(e_InputFilter_Type.INPUTFILTER_TYPE_HP);

		return true;
	}

	public bool Tick(float fDeltaTime)
	{
		 bool bRet = true;

		 if(!TickTouchStates(fDeltaTime))
		 	bRet = false;

		 if(!DisableCurFilter && CurFilter!=null && !CurFilter.Tick(fDeltaTime))
		 	bRet=false;

		 return bRet;
	}


	public bool OnLeaveGameWorld()
	{
		DisableCurFilter=false;
		return true;
	}


	protected ECInputFilter CreateFilter(e_InputFilter_Type inPutType)
	{
		switch(inPutType)
		{
			case e_InputFilter_Type.INPUTFILTER_TYPE_HP:
				return new ECHPInputFilter(this);
			default:
				return null;
		}
	}

	protected bool InitFilter()
	{
		return SetCurFilter(e_InputFilter_Type.INPUTFILTER_TYPE_HP);
	}


	protected virtual bool TickTouchStates(float fDeltaTime)
	{
		return true;
	}


}
