using UnityEngine;
using System.Collections;

public enum e_InputFilter_Type
{
	INPUTFILTER_TYPE_INVALID,
	INPUTFILTER_TYPE_HP,
}

public  class ECInputFilter  {
	public e_InputFilter_Type Type;
	public ECInputCtrl Ctrl;
	public virtual bool Tick(float fDeltaTime)
	{
		return true;
	}

	public ECInputFilter(e_InputFilter_Type eType, ECInputCtrl ctrl)
	{
		Type=eType;
		Ctrl = ctrl;
	}
}
