using UnityEngine;
using System.Collections;

public class ECMoveCamera:ECCamera  {

	
	public GameObject CameraObj;

	private Transform m_root;

	private Transform m_host_last;
	private Transform m_host;


	private Vector3 m_diff;

	public override void Start()
	{
		 Debug.Log("~~ECMoveCamera~~~~Start~~~~1~~");
		m_host=ECHostPlayer.Instance.transform;
		m_host_last=m_host;
		m_root=CameraObj.transform.parent;
		if(m_root==null) 
		{
			Debug.Log("~m_root~~");
		}
		m_diff=m_root.position-m_host.position;
	}
	public override void Update()
	{	
		Debug.Log("~~ECMoveCamera~~~~Update~~~2~");
		m_root.position = m_host.position+m_diff;
	}

}
