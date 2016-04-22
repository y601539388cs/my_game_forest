using UnityEngine;
using System.Collections;

public class FSMJoystickMove : FSMUnit {
	
	ECObject  m_object;
	Vector3 m_speed;
	Vector3 m_dir;
	public ECObject Mover
	{
	  get{return m_object;}
	  set{m_object = value;}
	}

	
	
	void Init()
	{
	   Priority = FSMPRIORITYTYPE.ACTION_MOVE;
       FSMType = "joystickMove";
	}
	public FSMJoystickMove(){Init();}
	public FSMJoystickMove(ECObject mover, Vector3 speed,Vector3 dir,RunHandlerDelegate func)
	{
	   Init();
	   this.Mover = mover;
	   this.m_speed=speed;
	   this.m_dir = dir;
	   this.m_runHandle=func;
	}
	
	bool IsNearDesPos()
	{ 
		
	  
	   return false;

	}
	public override bool Run()
	{
       if(IsNearDesPos())
	   {
			return false;
	   }
	   
	  // Vector3 newDir=(m_desPos-m_object.transform.position).normalized;

	  //m_object.transform.position = m_object.transform.position+newDir*speed;
	   m_runHandle();
	   return true;
	}
}
