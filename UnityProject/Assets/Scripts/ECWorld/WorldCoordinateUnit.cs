using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Force {
	public int DartNum = 0;
	Skill [] skillList = new Skill[10];

	public void AddSkill(Skill s)
	{
	  	skillList[DartNum]=s;
	  	DartNum=DartNum+1;
	}

	public void GetSkillHurt()
	{
		for(int i=0;i<DartNum;++i)
		{
			skillList[i].GetCollide();
		}	
	}

	public double AllHurt = 0;
	public double GetAllHurt()
	{
		
		for(int i=0;i<DartNum;++i)
		{
			AllHurt+=skillList[i].HurtUnit;
		}
		return AllHurt;
	}

	public void BeAttacked(double attack)
	{
		for(int i=0;i<DartNum;++i)
		{
			skillList[i].BeAttacked(attack);
		}
	}

}

public class WorldCoordinateUnit  {

	  public const int ForceNum = 3;
	  public int Legnth = 5;
      public int DartNum = 0;

	  Force [] forcelists = new Force[ForceNum];

	  public WorldCoordinateUnit()
	  {
	  	for(int i=0;i<ForceNum;++i)
	  	{
	  		forcelists[i]=new Force();
	  	}
	  }

	  public void AddSkill(Skill s)
	  {
	  	forcelists[(int)s.ForceID].AddSkill(s);
	  	DartNum=DartNum+1;
	  }
	  

	  public void Clear()
	  {
	  	for(int i=0;i<ForceNum;++i)
	  	{
	  		forcelists[i].DartNum=0;
	  		forcelists[i].AllHurt=0;
	  	}
	  	this.DartNum  = 0;
	  }

	  public void GetSkillHurt()
	  {
	  	if(DartNum<2)
	  	{
	  		return;
	  	} 
	  	for(int i=0;i<ForceNum;++i)
	  	{
	  		if(forcelists[i].DartNum>0)
	  		{
	  			forcelists[i].GetSkillHurt();
	  		}
	  	}
	  }

	  public void GetCollideResult()
	  {
	  	
	  	if(DartNum<2)
	  	{
	  		return;
	  	}
	  	double allHurt =0;
	  	for(int i=0;i<ForceNum;++i)
	  	{	
	  		allHurt+=forcelists[i].GetAllHurt();
	  	}

	  	for(int i=0;i<ForceNum;++i)
	  	{
	 		double attackNum = allHurt - forcelists[i].AllHurt;
	  		forcelists[i].BeAttacked(attackNum);
	  	}
	  }
}
