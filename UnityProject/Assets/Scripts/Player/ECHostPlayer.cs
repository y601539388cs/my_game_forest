using UnityEngine;
using System.Collections;

public class ECHostPlayer :  ECObject{
	private ECHostPlayer(){}
	ECHostPlayer m_inst;
	FSMList m_FSMList = new FSMList();
	public static ECHostPlayer Instance ()
	{
	   if (m_inst==null) 
	   {
	       m_inst=new ECHostPlayer();
	   }
	   return m_inst;
	}
}
