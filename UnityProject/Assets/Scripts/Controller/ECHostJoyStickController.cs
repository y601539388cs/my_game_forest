using UnityEngine;
using System.Collections;


public class ECHostJoyStickController : ECController {

	private Vector3 m_forward= new Vector3(0,0,1);
	private Vector3 m_left;
	private Vector3 m_right;
	private Vector3 m_back;

	public  Vector3 Forward
	{
		get{
			return m_forward;
		}
		set{
			m_forward=value.normalized;
			m_back=-m_forward;
			m_left=Vector3.Cross(m_forward, Up).normalized;
			m_right=-m_left;
		}
	}

	public Vector3 Up=new Vector3(0,1,0);
 	
 	private Vector3 m_origin = new Vector3(0,0,0);

 	FSMJoystickMove m_joystickFSM;
 	public static ECHostJoyStickController Instance = new ECHostJoyStickController();

	
	//int a = b();
	private  ECHostJoyStickController()
	{
		ControllerManager.Instance.AddListener(this);
		
	}

	//希望以后可以改进为消息监听模式
	public override void Start()
	{
		Forward = ECHostPlayer.Instance.Forward;
		m_joystickFSM = new FSMJoystickMove(ECHostPlayer.Instance,ECHostPlayer.Instance.Speed,Vector3.zero,null);
	}

	public bool GetDir(out Vector3 dir)
	{	
		bool flag=false;
		Vector3 forward = CameraManager.Instance.CurMainCamera.Root.forward;

		Forward = new Vector3( forward.x,0, forward.z);
		

		if (Input.GetKey(KeyCode.W))
		{
			m_origin+=m_forward;
			flag=true;
		} 

		if (Input.GetKey(KeyCode.S))
		{
			m_origin+=m_back;
			flag=true;
		} 

		if (Input.GetKey(KeyCode.A))
		{
			m_origin+=m_left;
			flag=true;
		} 

		if (Input.GetKey(KeyCode.D))
		{
			m_origin+=m_right;
			flag=true;
		} 
		dir=m_origin.normalized;
		m_origin=Vector3.zero;
		
		return flag;
	}

	bool m_firstSendMsg = true;
	public override void Listen()
	{
		//以后用命令表可以继续简化
		Vector3 outDir;
		bool cango = GetDir(out outDir);
		m_joystickFSM.pressing=cango;
		if(cango)
		{
			
			m_joystickFSM.MoveDir = outDir;
			if(m_firstSendMsg)
			{
				ECHostPlayer.Instance.MyFSMList.WeakPush(m_joystickFSM);
				m_firstSendMsg=false;
			}
		}
		else 
		{
			m_firstSendMsg=true;
		}
		
		
	}

}
