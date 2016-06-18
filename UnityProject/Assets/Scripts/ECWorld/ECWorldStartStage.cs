using UnityEngine;
using System.Collections;

public class ECWorldStartStage : ECWorldStage {

	void LoadInputSetting()
	{

	}

	// Use this for initialization
	public override void Load () {

		
	   //注册相机
	   GameObject mainCam= GameObject.Find("Main Camera");
	   
	   ECMoveCamera moveCam  =  new ECMoveCamera();
	   moveCam.CameraObj = mainCam;
	   CameraManager.Instance.CurMainCamera = moveCam;
	   CameraManager.Instance.RegisterCamera(moveCam);



	}
	
	// Update is called once per frame
	public override void UnLoad () {
	
	}
}
