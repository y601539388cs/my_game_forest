using UnityEngine;
using System.Collections;

public class FSMStand : FSMUnit {

	ECObject  m_object;
	
	public ECObject Stander
	{
	  get{return m_object;}
	  set{m_object = value;}
	}

	
	
	void Init()
	{
	   Priority = FSMPRIORITYTYPE.IDLE;
       FSMType = "stand";
	}
	public FSMStand(){Init();}
	public FSMStand(ECObject stander)
	{
	   Init();
	   this.Stander = stander;
	}
	
	public override bool Update()
	{
		return true;
	}
	public override bool Run()
	{
      return false;
	}
}
