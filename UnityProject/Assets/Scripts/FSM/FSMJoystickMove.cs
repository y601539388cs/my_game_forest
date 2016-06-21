using UnityEngine;
using System.Collections;

public class FSMJoystickMove : FSMUnit {
	
	ECObject  m_object;
	
	float m_speed;
	public float Speed{
		get{return m_speed;}
		set{m_speed=value;}
	}

	Vector3 m_moveDir;
	public  Vector3 MoveDir
	{
		get{return m_moveDir;}
		set{	
			m_moveDir=value;
		}
	}
	
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
	   this.Speed=speed;
	   this.MoveDir = dir;
	   this.m_runHandle=func;
	}

	public override bool Run()
	{
       
	   m_object.transform.rotation = Quaternion.LookRotation(m_moveDir);
	   m_object.MoveDir = m_moveDir;
	   m_object.Speed= m_speed;
	   
	   Vector3 ts=this.MoveDir*Speed*Time.deltaTime;
	  // Debug.Log("~~FSMJoystickMove~~~~Run~~~~~~~~"+ts.x+" "+ts.y+"  "+ts.z);
	  
	   Vector3 tempVc = m_object.transform.position+ts;
	   float tempy= ECUtility.GetSupportTerrainHeight(tempVc);

	   if(tempy!=0)
	   {
	   	 tempVc.y=tempy;
	   }

	   m_object.transform.position = tempVc;


	   if(m_runHandle!=null)
	   {
	   	  m_runHandle();
	   }
	   
	   return  !pressing;
	}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
}
