using UnityEngine;
using System.Collections;

public class ECHPInputFilter :ECInputFilter {
	public ECHPInputFilter(ECInputCtrl ctrl)
		:	base(e_InputFilter_Type.INPUTFILTER_TYPE_HP,ctrl)
		{

		}

	void UpdateToHandleInput()
	{	
		
		ECMoveCamera cam = CameraManager.Instance.CurMainCamera as ECMoveCamera;
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
	}
	
	public override bool Tick(float fDeltaTime)
	{
		UpdateToHandleInput();
		return true;
	}

}
