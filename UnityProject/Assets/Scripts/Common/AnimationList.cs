using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationList  {

	 Dictionary<string, Dictionary<string,string>> pList = new Dictionary<string, Dictionary<string,string>>();
	 void Load()
	 {
	 	pList["hostPlayer"]["stand"]="NomalIdle";
	 }
}
