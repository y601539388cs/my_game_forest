using UnityEngine;
using System.Collections;


public class TestController : ECController {

	int a = b();
	public static int test=10;
	static int g = gg();
	public static TestController Instance = new TestController();

	static int gg()
	{
		return 99;
	}
	
	static int d=100;
	static int b()
	{
		test=test+2;
		return test;
	}
	
	

	int c=9;
	private  TestController()
	{
		//ControllerManager.Instance.AddListener(this);
		test=9;
	}
	static  TestController()
	{
		
	}
	public static int  f=100;

	
	public override void Listen()
	{
		//以后用命令表可以继续简化
		
		if (Input.GetKeyDown(KeyCode.D))
	     {
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x+0.2f;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	ECHostPlayer hp = ECHostPlayer.Instance;
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x-0.2f;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	ECHostPlayer hp = ECHostPlayer.Instance;
	     	Vector3 pos = ECHostPlayer.Instance.transform.position;
	     	pos.x=pos.x-0.2f;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance,pos,ECHostPlayer.Instance.Move);
	     	ECHostPlayer.Instance.MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.S))
	     {
	     	
	     }	
	}

}
