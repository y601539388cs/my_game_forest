using UnityEngine;
using System.Collections;

public class ECHostPlayer :  ECObject{
	private ECHostPlayer(){}
	
	//状态机
	FSMList m_FSMList = new FSMList();
	public FSMList MyFSMList
	{
		get{return m_FSMList;}
		private set{}
	}

	public static ECHostPlayer Instance = new ECHostPlayer();
	
	//控制器
	private ECHostController m_ctroller = ECHostController.Instance;

	public void Move()
	{
		
	}

	void Start()
	{
		
	}
	void Update () {
		m_FSMList.Run();
	}

}
