using UnityEngine;
using System.Collections;

public class FSMMove : FSMUnit {
	Vector3 m_desPos;
	ECObject  m_object;
	int speed = 2;

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
       FSMType = "move";
	}
	public FSMMove(){Init();}
	public FSMMove(ECObject mover, Vector3 desPos,RunHandlerDelegate func)
	{
	   Init();
	   this.DesPos=desPos;
	   this.Mover = mover;
	   this.m_runHandle=func;
	}
	
	bool IsNearDesPos()
	{ 
		
	   if(System.Math.Abs(m_object.transform.position.x-m_desPos.x)<2)
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
