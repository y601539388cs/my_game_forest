using UnityEngine;
using System.Collections;

public class EntryPoint : MonoBehaviour {
	
	public float CurTime;
	public float DeltaTime;
	// Use this for initialization
	//SkillManager m_skillManager = SkillManager.Instance;
	ControllerManager m_controllerManager = ControllerManager.Instance;
	ECObjectManager m_objectManager = ECObjectManager.Instance;
	ECTimerManager m_timerManager = ECTimerManager.Instance;
	CameraManager m_cameraManager = CameraManager.Instance;
	ECWorldStageManager m_worldStageManager = ECWorldStageManager.Instance;
	ECInputManager m_inputManager = ECInputManager.Instance;
	//test
	//Skill_FireBall m_fireBall;
	//Skill_FireBall m_fireBall_op;

	void Start () {

		 InitGame();
		 m_objectManager.Start();
		 m_timerManager.Start();
		 m_controllerManager.Start();
		 m_cameraManager.Start();
		 m_inputManager.Start();

	}
	
	
	void InitGame()
	{
		//
		ECWorldStartStage  startStage = new ECWorldStartStage();
		m_worldStageManager.LoadStage(startStage);

		//test
		// Transform root = GameObject.Find("Skill_Ball").transform;
		// m_fireBall = new Skill_FireBall(1,10,1,root,SKILLFORCE.YVY,1);
		// Transform root_op = GameObject.Find("Skill_Ball_op").transform;
		// m_fireBall_op = new Skill_FireBall(1,10,1,root_op,SKILLFORCE.YOYO,-1);
	}

	// Update is called once per frame

	
	void Run()
	{
		//m_skillManager.Run();
		//m_skillManager.FreshAttack();
	}

	void Update () {
		 CurTime = Time.time;
		 DeltaTime = Time.deltaTime;

		 m_controllerManager.Listen();
         m_objectManager.Update();
         m_timerManager.Update();
         m_inputManager.Tick(DeltaTime);
	} 


	void LateUpdate()
	{
		 m_cameraManager.Update();
		  m_inputManager.LateTick();
	}

	 void OnGUI() {
	 }
}
