using UnityEngine;
using System.Collections;

public class SkillNone: Skill {


	// Use this for initialization
	public static SkillNone Instance = new SkillNone();
	private SkillNone()
	{
		
	}

	
	public override void GetCollide()
	{
		
	}

	public double HurtUnit = 0;

	public override void GetHurtUnit()
	{
		
	}
	public override void Clear()
	{
		
	}

	public override void BeAttacked(double attackNum)
	{
		

	}
	
	public override Skill Born()
	{

		return this;
	}

	public override Skill Clone (Skill s)
	{
		return this;
	}

	public override void Over()
	{
		
	}
	public  override double GetHurt()
	{
		return 0;
	}

	public override void FreshSkillScope()
	{

	}
	public override void Run(){}

    public override void Effect(){}

    public override void PlayOver(){
    	
    }





	
}
