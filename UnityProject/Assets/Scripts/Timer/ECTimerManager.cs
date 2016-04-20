using UnityEngine;
using System.Collections;




public class ECTimerManager  {
	public static ECTimerManager  Instance  = new ECTimerManager();
	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	  Debug.Log("~~~~~~~~~~~~~~"+Time.realtimeSinceStartup);
	  Debug.Log("~~~~~~~~~~~~~~"+Time.deltaTime);
	}
}
