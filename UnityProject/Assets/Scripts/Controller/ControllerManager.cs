using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerManager  {

	private ControllerManager()
	{

	}
	public static ControllerManager Instance = new ControllerManager();
	
	private List<ECController>  m_listeners = new List<ECController>();

	public void AddListener(ECController c)
	{
		m_listeners.Add(c);
	}

	public void Start()
	{
		for(int i=0;i<m_listeners.Count;++i)
		{
			m_listeners[i].Start();
		}
	}

	public void Listen()
	{
		for(int i=0;i<m_listeners.Count;++i)
		{
			m_listeners[i].Listen();
		}
	}
}
