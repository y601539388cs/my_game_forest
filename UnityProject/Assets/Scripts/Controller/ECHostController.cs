using UnityEngine;
using System.Collections;


public class ECHostController : ECController {

	
	
	public static ECHostController Instance = new ECHostController();

	
	public static int test=1;
	static int b()
	{
		Debug.Log("~~~~test~~~~~~~"+test);
		Debug.Log("~~~~test~~~~~~~"+ECHostController.test);
		test=test+2;
		return test;
	}
	
	//int a = b();
	private  ECHostController()
	{
		ControllerManager.Instance.AddListener(this);
		Debug.Log("~~~ECHostController~test~~~~~~~"+test);
		test=9;
	}
	public override void Listen()
	{
		//以后用命令表可以继续简化
		
		if (Input.GetKeyDown(KeyCode.D))
	     {
	     	Debug.Log("~~~~~a~~~~~~~");
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x+0.2f;
	     	Debug.Log("~~~~~~(KeyCode.D)~~~~~~~~");
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	ECHostPlayer hp = ECHostPlayer.Instance;
	     	Debug.Log("~~~~~~~~~~~~~~~~`"+hp.test);
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x-0.2f;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	ECHostPlayer hp = ECHostPlayer.Instance;
	     	Debug.Log("~~~~~~~~~~~~~~~~`"+hp.test);
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x-0.2f;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.S))
	     {
	     	 Debug.Log("~~~~~~~~~~s~~~~~~~~");
	     	//m_fireBall.Born();
	     	//m_fireBall_op.Born();
	     }	
	}

}
