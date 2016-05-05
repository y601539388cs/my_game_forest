using UnityEngine;
using System.Collections;


public class ECHostController : ECController {

	
	
	public static ECHostController Instance = new ECHostController();

	
	//int a = b();
	private  ECHostController()
	{
		//ControllerManager.Instance.AddListener(this);
		
	}


	public override void Listen()
	{
		//以后用命令表可以继续简化
		
		
	}

}
