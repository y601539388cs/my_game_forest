using UnityEngine;
using System.Collections;

public class FSMJoystickMove : FSMUnit {
	
	ECObject  m_object;
	float m_speed;
	Vector3 m_dir;
	public bool pressing = true;
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
	public FSMJoystickMove(ECObject mover, float speed,Vector3 dir,RunHandlerDelegate func)
	{
	   Init();
	   this.Mover = mover;
	   this.m_speed=speed;
	   this.m_dir = dir;
	   this.m_runHandle=func;
	}

	public override bool Run()
	{
       
	   
	  //Vector3 newDir=(m_desPos-m_object.transform.position).normalized;
	
	   m_object.transform.position = m_object.transform.position+this.m_dir*m_speed*Time.deltaTime;
	   m_runHandle();
	   return pressing;
	}
}
