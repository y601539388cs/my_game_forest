using UnityEngine;
using System.Collections;

enum SKILLFORCE
{
	YVY=0;
	YOYO=1;
	JINGJING=2;
}

public abstract class Skill  {

	long m_id=0;
	public long ID{
		get{return m_id;}
	}
	
	int m_life=0;
	public int Life{
		get{return m_life;}
	}
	int m_attack=0;
	public int Attack{
		get{return m_attack;}
	}

	int  m_hurtCoefficient=0;
	public int HurtCoefficient
	{
		get{return m_hurtCoefficient;}
	}


	public SKILLFORCE ForceID = SKILLFORCE.YVY;
	public int SkillHurtRange = 0;

	public void GetCollide()
	{
		++SkillHurtRange;
	}

	public void Clear()
	{
		SkillHurtRange=0;
	}

	private Transform m_root=null;

	public Skill(int life,int attack,int hurtCoefficient, Transform root )
	{
		this.m_life=life;
		this.m_attack=attack;
		this.m_hurtCoefficient=hurtCoefficient;
		this.m_root=root;
	}

	private int m_Index = 0;
	public Skill Born()
	{

		this.m_Index = SkillManager.Instance.AddSkill(this);
		return this;
	}

	public Skill Clone (Skill s)
	{
		this.m_life=s.m_life;
		this.m_attack=s.m_attack;
		this.m_hurtCoefficient=s.m_hurtCoefficient;
		this.m_root=s.m_root;
		return this;
	}

	public void Over()
	{
		SkillManager.Instance.RemoveSkill(this.m_Index);
	}
	public  virtual int GetHurt()
	{
		return Attack*HurtCoefficient;
	}

	public virtual void Run(){}

    public virtual void Effect(){}

    public virtual void Over(){}




}
