using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ECInputManager  {

	public static ECInputManager Instance = new ECInputManager();
	//ECInputCtrl ctrl;

	private List<ECInputFilter>  m_listeners = new List<ECInputFilter>();

	public void AddListeners(ECInputFilter inputFilter)
	{
		inputFilter.Start();
		m_listeners.Add(inputFilter);
	}

	void Init()
	{
		
	}	
	public void Start()
	{
		Init();
	}

	public void Tick(float fDeltaTime)
	{
		for(int i=0;i<m_listeners.Count;++i)
		{
			m_listeners[i].Tick(fDeltaTime);
		}
	}

	public void LateTick()
	{
		for(int i=0;i<m_listeners.Count;++i)
		{
			m_listeners[i].OnFrameEnd();
		}
	}

}
