using UnityEngine;
using System.Collections;

public class ECHostController : ECController {

	private  ECHostController()
	{
		ControllerManager.Instance.AddListener(this);
	}
	
	public static ECHostController Instance = new ECHostController();

	
	public override void Listen()
	{
		//以后用命令表可以继续简化
		if (Input.GetKeyDown(KeyCode.D))
	     {
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x+20;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x-20;
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
