using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCoordinateUnit  {

public:
	 int Legnth = 5;
      int DartNum = 0;
	  ArrayList list = new ArrayList(10);

	  void AddSkill(Skill s)
	  {
	  	list[DartNum]=s;
	  	DartNum=DartNum+1;
	  }
	  

	  void Clear()
	  {

	  }
}
