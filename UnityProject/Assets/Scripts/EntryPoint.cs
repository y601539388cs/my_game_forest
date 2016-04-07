using UnityEngine;
using System.Collections;

public class EntryPoint : MonoBehaviour {
	
	// Use this for initialization
	SkillManager m_skillManager = SkillManager.Instance;
	void Start () {

		
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
		
	     Run();
	} 
}
