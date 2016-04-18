using UnityEngine;
using System.Collections;

public class EntryPoint : MonoBehaviour {
	
	// Use this for initialization
	//SkillManager m_skillManager = SkillManager.Instance;
	ControllerManager m_controllerManager = ControllerManager.Instance;
	ECHostPlayer m_host;
	//test
	//Skill_FireBall m_fireBall;
	//Skill_FireBall m_fireBall_op;

	void Start () {

		 InitGame();
	}
	
	
	void InitGame()
	{
		//
		m_host = ECHostPlayer.Instance;

		//test
		// Transform root = GameObject.Find("Skill_Ball").transform;
		 Debug.Log("~~~~~~~~~~m_fireBall~~~~~~~~~~~~");
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
		 m_controllerManager.Listen();
         
		
	     Run();
	} 
}
