using UnityEngine;
using System.Collections;

public class ECWorldStageManager  {

	public static ECWorldStageManager Instance = new ECWorldStageManager();

	private ECWorldStage curStage;
	public void LoadStage(ECWorldStage newStage)
	{
		if(curStage!=null)
		{
			curStage.UnLoad();	
		}
		
		newStage.Load();
		curStage=newStage;
	}

	public void Over()
	{
		if(curStage!=null)
		{
			curStage.UnLoad();
		}
		curStage=null;
	}
}
