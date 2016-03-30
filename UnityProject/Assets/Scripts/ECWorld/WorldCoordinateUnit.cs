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
}

public class WorldCoordinateUnit  {


	  public int Legnth = 5;
      public int DartNum = 0;
	  Force [] forcelists = new Force[3];

	  public void AddSkill(Skill s)
	  {
	  	forcelists[s.ForceID].AddSkill(s);
	  	DartNum=DartNum+1;
	  }
	  

	  public void Clear()
	  {
	  	for(int i=0;i<3;++i)
	  	{
	  		forcelists[i].DartNum=0;
	  	}
	  	this.DartNum  = 0;
	  }

	  public void GetSkillHurt()
	  {
	  	for(int i=0;i<3;++i)
	  	{
	  		if(forcelists[i].DartNum>0)
	  		{
	  			forcelists[i].GetSkillHurt();
	  		}
	  	}
	  }
}
