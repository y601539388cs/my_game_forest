using UnityEngine;
using System.Collections;

public class ECCamera  {

	public GameObject CameraObj;

	protected Transform m_root;
	public Transform Root{
		get{return m_root;}
	}

	protected Transform m_host_last;
	protected Transform m_host;


	protected Vector3 m_diff;

    public string Type="Camera";

	public  Vector3 Diff
	{
		get{return m_diff;}
		set{m_diff=value;}
	}

	public virtual void Start()
	{

	}


	public virtual void Update()
	{
		
	}
}
