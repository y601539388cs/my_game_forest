
using UnityEngine;
using System.Collections;

public class ECHostPlayer :  ECObject{
	
	private ECHostPlayer(){
		ECObjectManager.Instance.Add(this);
	}
	
	public Vector3 Forward = new Vector3(0,0,1);
	//状态机
	FSMList m_FSMList = new FSMList();
	public FSMList MyFSMList
	{
		get{return m_FSMList;}
		private set{}
	}

	public static ECHostPlayer Instance = new ECHostPlayer();
	public int test=3;
	//控制器
	private ECHostJoyStickController m_ctroller = ECHostJoyStickController.Instance;

	public float Speed = 6.0f;
	public void Move()
	{

	}



   

	public override void Start()
	{	
		bool bb=false;
		if(bb)
		{
			TestController m_ctroller2 = TestController.Instance;
		}
		//初始化
		transform = GameObject.Find("HostPlayer").transform;
		
		
	}

	public override void Update () {
		//Debug.Log("~~~~~~~~Update~~~~~~~");
		m_FSMList.Run();
	}

}
