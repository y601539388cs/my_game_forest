using UnityEngine;
using System.Collections;

public class ECHostPlayer :  ECObject{
	private ECHostPlayer(){}
	static ECHostPlayer m_inst;
	FSMList m_FSMList = new FSMList();
	public FSMList MyFSMList
	{
		get{return m_FSMList;}
		private set{}
	}

	public static ECHostPlayer Instance ()
	{
	   if (m_inst==null) 
	   {
	      
	   }
	   return m_inst;
	}

	public void Move()
	{
		
	}

	void Start()
	{
		m_inst=this;
	}
	void Update () {
		m_FSMList.Run();
	}

}
