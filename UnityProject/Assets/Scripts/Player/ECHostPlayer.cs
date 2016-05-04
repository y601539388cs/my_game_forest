﻿using UnityEngine;
using System.Collections;

public class ECHostPlayer :  ECObject{
	
	private ECHostPlayer(){
		ECObjectManager.Instance.Add(this);
	}
	
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
	private ECHostController m_ctroller = ECHostController.Instance;


	public void Move()
	{

	}



   

	public override void Start()
	{	
		bool bb=false;
		if(bb)
		{
				Debug.Log("~~~~~~~~m_ctroller2~1~");
				TestController m_ctroller2 = TestController.Instance;
				Debug.Log("~~~~~~~~m_ctroller2~2~"+TestController.f);

	
		}
		//初始化
		transform = GameObject.Find("HostPlayer").transform;
		
		
	}

	public override void Update () {
		//Debug.Log("~~~~~~~~Update~~~~~~~");
		m_FSMList.Run();
	}

}
