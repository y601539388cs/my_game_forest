using UnityEngine;
using System.Collections;

interface Imyface
{

	int Geta();
	int S{get;set;}
}

public class TestTex :  Imyface{
	public int Geta()
	{
		return 0;
	}
	int s;
	public int S{
		get{return 0;}
		set{ s=value;}
	}

	public void Run()
	{
		//Debug.Log("~~~~111~~~");
	}

}
