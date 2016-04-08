using UnityEngine;
using System.Collections;

public class Skill_FireBall: Skill {


	// Use this for initialization

	public Skill_FireBall()
	{
		m_id = 1;
		m_life=1;
		m_attack=10;
	}

	public float m_dir; 
	public  Skill_FireBall(int life,int attack,int hurtCoefficient, Transform root,SKILLFORCE sf, float dir ):base(life,attack,hurtCoefficient,root)
	{
		m_dir=dir;
		ForceID=sf;	
	}

	public override void FreshSkillScope()
	{
		WorldCoordinate wc = WorldCoordinate.Instance;
		int x = (int)m_root.position.x;
		int y = (int)m_root.position.y;

		wc.AddSkill(x-1,y-1,this);
		wc.AddSkill(x,y-1,this);
		wc.AddSkill(x+1,y-1,this);
		wc.AddSkill(x-1,y,this);
		wc.AddSkill(x,y,this);
		wc.AddSkill(x+1,y,this);
		wc.AddSkill(x-1,y+1,this);
		wc.AddSkill(x,y+1,this);
		wc.AddSkill(x+1,y+1,this);

		

	}

	public override void Run()
	{
		float x=m_root.position.x+1.0f*m_dir;
		Debug.Log("~~~~~~~~~~~~"+m_dir+"~~~~"+x);
		
		m_root.position=new Vector3(x, m_root.position.y, m_root.position.z);

	}
	
	
}
