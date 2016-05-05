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
		Debug.Log("~~~~ECHostJoyStickController~~~~~Start~~~~~~");
		Forward = ECHostPlayer.Instance.Forward;
		m_joystickFSM = new FSMJoystickMove(ECHostPlayer.Instance,ECHostPlayer.Instance.Speed,Vector3.zero,null);
	}

	public bool GetDir(out Vector3 dir)
	{	
		bool flag=false;
		if (Input.GetKeyDown(KeyCode.W))
		{
			m_origin+=m_forward;
			flag=true;
		} 

		if (Input.GetKeyDown(KeyCode.S))
		{
			m_origin+=m_back;
			flag=true;
		} 

		if (Input.GetKeyDown(KeyCode.A))
		{
			m_origin+=m_left;
			flag=true;
		} 

		if (Input.GetKeyDown(KeyCode.D))
		{
			m_origin+=m_right;
			flag=true;
		} 
		dir=m_origin.normalized;
		m_origin=Vector3.zero;
		return flag;
	}
	public override void Listen()
	{
		//以后用命令表可以继续简化
		//Debug.Log("~~Listen~~");
		bool cango = GetDir(out m_joystickFSM.MoveDir);
		m_joystickFSM.pressing=cango;
		if(cango)
		{	
			Debug.Log("~~~~~~~~~~~~"+m_joystickFSM.MoveDir.x);
		    ECHostPlayer.Instance.MyFSMList.Replace(m_joystickFSM);
		}
		
	}

}
