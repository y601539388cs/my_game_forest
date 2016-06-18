﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager  {

	private CameraManager()
	{

	}

	
	public static CameraManager Instance = new CameraManager();
	
	public ECCamera CurMainCamera;// main camera
	List<ECCamera> m_camList = new List<ECCamera>(); //cameraMode


	public void RegisterCamera(ECCamera newCam)
	{
		m_camList.Add(newCam);
		newCam.Start();
	} 
	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
		for(int i=0;i<m_camList.Count;++i)
        {

        	m_camList[i].Update();
        }
	}
}
