using UnityEngine;
using System.Collections;

public class ECMoveCamera:ECCamera  {

	
	
	
	Vector3 m_offeset = new Vector3(0,0,0);
	float OFFSETANGLE_UP=30;
	public override void Start()
	{
		Type="MoveCamera";
		m_host=ECHostPlayer.Instance.transform;
		m_host_last=m_host;
		m_root=CameraObj.transform.parent;
		
		m_diff=m_root.position-m_host.position;
	}
	public override void Update()
	{	

		m_root.position = m_host.position+m_offeset+m_diff;
	}

	public void YawCamera(float delta)
	{
		Vector3 hostpos = m_root.position-m_diff;
		m_root.LookAt(hostpos);
		m_root.RotateAround(hostpos,Vector3.up,-delta);
		m_root.LookAt(hostpos);
		m_diff = m_root.position - hostpos;
	}

	public void PitchCamera(float delta)
	{
		Vector3 hostpos = m_root.position-m_diff;
		m_root.LookAt(hostpos);
		Vector3 dir = m_root.forward;

		float angle1 = Vector3.Angle(dir,-Vector3.up);
		float angle2 =angle1 - delta;
		if(angle2< OFFSETANGLE_UP)
		{
			delta=60-(90-angle1);
		}
		else if(angle2>120)
		{
			delta=-30+(angle1-90);
		}

		m_root.RotateAround(hostpos,m_root.right,delta);
		m_root.LookAt(hostpos);
		m_diff=m_root.position-hostpos;

	}

}
