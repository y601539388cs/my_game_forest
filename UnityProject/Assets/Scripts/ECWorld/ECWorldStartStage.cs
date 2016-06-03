using UnityEngine;
using System.Collections;

public class ECWorldStartStage : ECWorldStage {


	// Use this for initialization
	public override void Load () {
	   //注册相机
	   Debug.Log("~~~~~~Load~~~1~~~");
	   GameObject mainCam= GameObject.Find("Main Camera");
	   if(mainCam==null)
	   {
	   	 Debug.Log("!!!!!!!!!!@@@!!!!!!!");
	   }
	   CameraManager.Instance.curMainCamera = mainCam;
	   ECMoveCamera moveCam  =  new ECMoveCamera();
	   moveCam.CameraObj = mainCam;
	   CameraManager.Instance.RegisterCamera(moveCam);
	}
	
	// Update is called once per frame
	public override void UnLoad () {
	
	}
}
