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

	public override void FreshSkillScope()
	{
		WorldCoordinate wc = WorldCoordinate.Instance;
		int x = (int)m_root.position.x;
		int y = (int)m_root.position.y;
		wc.AddSkill(x-1,y-1,s);
		wc.AddSkill(x,y-1,s);
		wc.AddSkill(x+1,y-1,s);
		wc.AddSkill(x-1,y,s);
		wc.AddSkill(x,y,s);
		wc.AddSkill(x+1,y,s);
		wc.AddSkill(x-1,y+1,s);
		wc.AddSkill(x,y+1,s);
		wc.AddSkill(x+1,y+1,s);

	}

	public override void Run()
	{
		float x=m_root.position.x+1;
		m_root.position.x=x;
	}
	
	
}
