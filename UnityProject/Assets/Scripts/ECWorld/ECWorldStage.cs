using UnityEngine;
using System.Collections;

public abstract class ECWorldStage  {

	// Use this for initialization
	public abstract void Load ();
	
	// Update is called once per frame
	public abstract void UnLoad () ;
}
