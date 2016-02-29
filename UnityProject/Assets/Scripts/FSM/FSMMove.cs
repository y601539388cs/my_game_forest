using UnityEngine;
using System.Collections;

public class FSMMove : FSMUnit {
	Vector3 m_desPos;
	ECObject  m_objct;
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
              DesPos=value;
	   }
	}
	
	void Init()
	{
	   Priority = FSMPRIORITYTYPE.ACTION_MOVE;
       FSMType = "move";
	}
	public FSMMove(){Init();}
	public FSMMove(ECObject mover, Vector3 desPos)
	{
	   Init();
	   this.DesPos=desPos;
	   this.Mover = mover;
	}
	
	bool IsNearDesPos()
	{
		
	   if(System.Math.Abs(m_objct.CurPos.x-m_desPos.x)<2)
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
	   m_object
	   m_objct.AddAction(
	}
}
