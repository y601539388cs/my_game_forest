using UnityEngine;
using System.Collections;



public  class ECInputFilter  {
	
	public virtual bool Tick(float fDeltaTime)
	{
		return true;
	}

	
	public virtual void Start()
	{
		
	}
	public virtual void  OnFrameEnd()
	{

	}
}
