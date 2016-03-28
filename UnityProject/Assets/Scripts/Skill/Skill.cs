using UnityEngine;
using System.Collections;

public abstract class Skill  {

	long m_id=0;
	public long ID{
		get{return m_id;}
	}
	int m_faction=0;
	public int Faction{
		get{return m_faction;}
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

	private Transform m_root=null;

	public Skill(int life,int attack,int hurtCoefficient, Transform root )
	{
		this.m_life=life;
		this.m_attack=attack;
		this.m_hurtCoefficient=hurtCoefficient;
		this.m_root=root;
	}

	public  virtual int GetHurt()
	{
		return Attack*HurtCoefficient;
	}

	public abstract void Run();

    public abstract void Effect();

    public virtual void Over(){};
}
