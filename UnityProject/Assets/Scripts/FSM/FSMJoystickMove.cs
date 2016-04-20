using UnityEngine;
using System.Collections;

public class FSMMove : FSMUnit {
	
	ECObject  m_object;
	Vector3 m_speed = 0.1f;
	Vector3 m_dir = 1.0f;
	public ECObject Mover
	{
	  get{return m_object;}
	  set{m_object = value;}
	}

	public Vector3 DesPos
	{
	   set
	   {
              m_desPos=value;
	   }
	}
	
	void Init()
	{
	   Priority = FSMPRIORITYTYPE.ACTION_MOVE;
       FSMType = "joystickMove";
	}
	public FSMMove(){Init();}
	public FSMMove(ECObject mover, Vector3 speed,Vector3 dir,RunHandlerDelegate func)
	{
	   Init();
	   this.Mover = mover;
	   this.m_speed=speed;
	   
	   this.m_runHandle=func;
	}
	
	bool IsNearDesPos()
	{ 
		
	   if(System.Math.Abs(m_object.transform.position.x-m_desPos.x)<0.1f)
	   {
		   return true;
	   }
	   return false;

	}
	public override bool Run()
	{
       if(IsNearDesPos())
	   {
			return false;
	   }
	   
	   Vector3 newDir=(m_desPos-m_object.transform.position).normalized;

	   m_object.transform.position = m_object.transform.position+newDir*speed;
	   m_runHandle();
	   return true;
	}
}
