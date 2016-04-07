using UnityEngine;
using System.Collections;

public class Skill_FireBall: Skill {


	// Use this for initialization

	void Skill_FireBall()
	{
		m_id = 1;
		m_life=1;
		m_attack=10;
	}

	public override void FreshSkillScope()
	{
		m_root
	}
	
}
