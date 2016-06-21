using UnityEngine;
using System.Collections;
using System;

public class FSMJump : FSMUnit {

	ECObject  m_object;


	public ECObject Jumper
	{
	  get{return m_object;}
	  set{m_object = value;}
	}

	float m_height=0;
	float v0=0;
	const float g = 10.0f;

	public float Height
	{
		set{
				m_height=value;
				v0=(float)Math.Sqrt(m_height*2*g);
			}
		get{return m_height;}
	}
	void Init()
	{
	   Priority = FSMPRIORITYTYPE.ACTION_JUMP;
       FSMType = "jump";
       Height=3.5f;
	}
	public FSMJump(){Init();}
	public FSMJump(ECObject jumper, RunHandlerDelegate func)
	{
	   Init();
	   this.Jumper = jumper;
	   this.m_runHandle=func;
	}
	
	
	float m_jumpTime=0;
	float m_orgy=0;
	public override bool Update()
	{
		m_orgy=m_object.transform.position.y;
		return true;
	}
	public override bool Run()
	{
        Vector3 ts=Jumper.MoveDir*Jumper.Speed*Time.deltaTime;
	  // Debug.Log("~~FSMJoystickMove~~~~Run~~~~~~~~"+ts.x+" "+ts.y+"  "+ts.z);
	  
	    Vector3 tempVc = m_object.transform.position+ts;
	    float tempy= ECUtility.GetSupportTerrainHeight(tempVc);

	    m_jumpTime=m_jumpTime+Time.deltaTime;
	    float v1=v0-m_jumpTime*g;
	    float h=(v0+v1)*m_jumpTime/2+m_orgy;
	    
	    bool jumpEnd=false;
	   // Debug.Log("~~~~Jumper~~~~~~"+tempy+"    "+h+"      "+orgy);
	    if(h<=tempy)
		{
			tempVc.y=tempy;		
			jumpEnd=true;
			m_jumpTime=0;
		}
		else
		{
			tempVc.y=h;
			jumpEnd=false;
		}

	   
		m_object.transform.position=tempVc;
	   if(m_runHandle!=null)
	   {
	   		m_runHandle();
	   }
	   	
	   	return jumpEnd;
	}
}
