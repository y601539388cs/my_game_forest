using UnityEngine;
using System.Collections;

public class FSMJoystickMove : FSMUnit {
	
	ECObject  m_object;
	float m_speed;
	public  Vector3 MoveDir;
	
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
	   this.MoveDir = dir;
	   this.m_runHandle=func;
	}

	public override bool Run()
	{
       
	   
	  //Vector3 newDir=(m_desPos-m_object.transform.position).normalized;
	   Vector3 ts=this.MoveDir*m_speed*Time.deltaTime;
	   Debug.Log("~~FSMJoystickMove~~~~Run~~~~~~~~"+ts.x+" "+ts.y+"  "+ts.z);
	  
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
	   if(pressing)
	   {
	   	Debug.Log("~~~~~pressing!!!~~~~");
	   }else
	   {
	   	Debug.Log("~~not~~~pressing!!!~~~~");
	   }
	   return  !pressing;
	}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
}
