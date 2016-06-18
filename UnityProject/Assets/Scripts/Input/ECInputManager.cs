using UnityEngine;
using System.Collections;

public class ECInputManager  {

	public static ECInputManager Instance = new ECInputManager();
	ECInputCtrl ctrl;

	void Init()
	{
		#if UNITY_IPHONE || UNITY_ANDROID
			ctrl = new ECTouchInputCtrl();
		#else
			ctrl = new ECMouseInputCtrl();
		#endif
			ctrl.Init();
	}	
	public void Start()
	{
		Init();
	}

	public void Tick(float fDeltaTime)
	{
		ctrl.Tick(fDeltaTime);
	}

}
