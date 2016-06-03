using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ECObjectManager {

	// Use this for initialization
	private ECObjectManager()
	{

	}
	public static ECObjectManager Instance = new ECObjectManager();

	private List<ECObject>  m_objectList = new List<ECObject>();

	public void Add(ECObject obj)
	{
		m_objectList.Add(obj);
		obj.Start();
	}
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		foreach(ECObject item in m_objectList)
		{
			item.Update();
		}
	}
}
