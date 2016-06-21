using UnityEngine;
using System.Collections;

public class ECHPInputFilter :ECInputFilter {
	public ECInputCtrl Ctrl ;
	public ECHPInputFilter()
	{

	}


	FSMJump m_jumpFSM;
	public override void Start()
	{
		#if UNITY_IPHONE || UNITY_ANDROID
			Ctrl = ECTouchInputCtrl.Instance;
		#else
			Ctrl = ECMouseInputCtrl.Instance;
		#endif
			Ctrl.Init();
		m_jumpFSM = new FSMJump(ECHostPlayer.Instance,null);
	}



	ECMoveCamera cam;
	void UpdateKeyBoard()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			ECHostPlayer.Instance.MyFSMList.WeakPush(m_jumpFSM);
		}
	}

	void UpdateScrollWheelInput()
	{	
		if(Ctrl.ScrollAxis>0)
		{
			cam.Move(-0.25f);
		}
		else if(Ctrl.ScrollAxis<0)
		{
			cam.Move(0.25f);
		}
	}
	void UpdateToHandleInput()
	{	
		
		cam = CameraManager.Instance.CurMainCamera as ECMoveCamera;
		if(cam==null){return;}
		if(Ctrl.TouchCount==1)
		{
			TouchState touchState0 = Ctrl.TouchStates[0];

			if(touchState0.ThisTouch.phase !=TouchPhase.Began && touchState0.HasMoved && touchState0.BeginTouch.phase == TouchPhase.Began)
			{
				Vector2 dist = touchState0.ThisTouch.position - touchState0.LastTouch.position;
				
				if(dist.x!=0)
				{
					cam.YawCamera(-dist.x/5);
				}
				if(dist.y!=0)
				{
					cam.PitchCamera(dist.y/10);
				}
			}
		}

		UpdateScrollWheelInput();
		UpdateKeyBoard();
	}
	
	void UpdateInputCtrl(float fDeltaTime)
	{
		Ctrl.Tick(fDeltaTime);
	}

	public override bool Tick(float fDeltaTime)
	{
		
		UpdateInputCtrl(fDeltaTime);
		UpdateToHandleInput();
		return true;
	}

	public override void  OnFrameEnd()
	{
		Ctrl.OnFrameEnd();
	}

}
