using UnityEngine;
using System.Collections;

public class EntryPoint : MonoBehaviour {
	
	// Use this for initialization
	SkillManager m_skillManager = SkillManager.Instance;
	//test
	Skill_FireBall m_fireBall;
	Skill_FireBall m_fireBall_op;

	void Start () {

		 Transform root = GameObject.Find("Skill_Ball").transform;
		 Debug.Log("~~~~~~~~~~m_fireBall~~~~~~~~~~~~");
		 m_fireBall = new Skill_FireBall(1,10,1,root,SKILLFORCE.YVY,1);
		 Transform root_op = GameObject.Find("Skill_Ball_op").transform;
		 m_fireBall_op = new Skill_FireBall(1,10,1,root_op,SKILLFORCE.YOYO,-1);
	}
	
	// Update is called once per frame

	void Run()
	{
		m_skillManager.Run();
		m_skillManager.FreshAttack();
	}

	void Update () {
         if (Input.GetKeyDown(KeyCode.D))
	     {
	     	Vector3 pos = ECHostPlayer.Instance().transform.position;
	     	pos.x=pos.x+20;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance(),pos,ECHostPlayer.Instance().Move);
	     	ECHostPlayer.Instance().MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.A))
	     {
	     	Vector3 pos = ECHostPlayer.Instance().transform.position;
	     	pos.x=pos.x-20;
	     	FSMMove moveState = new FSMMove(ECHostPlayer.Instance(),pos,ECHostPlayer.Instance().Move);
	     	ECHostPlayer.Instance().MyFSMList.StrongPush(moveState);
	     }
	     else if (Input.GetKeyDown(KeyCode.S))
	     {
	     	 Debug.Log("~~~~~~~~~~s~~~~~~~~");
	     	m_fireBall.Born();
	     	m_fireBall_op.Born();
	     }
		
	     Run();
	} 
}
