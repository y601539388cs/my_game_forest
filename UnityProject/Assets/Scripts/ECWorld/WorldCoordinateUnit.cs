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
	  

	  void Clear()
	  {

	  }
}
