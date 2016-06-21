using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSMList{
     List<FSMUnit> list = new List<FSMUnit>();
     FSMUnit m_lastState;
     public FSMUnit CurState
     {
	    get{return list[0];}
     }
     void Init()
     {
		 list.Add(FSMUnit.FSMNullState);
		 m_lastState=CurState;
     }
     public FSMList()
     {
	    Init();
     }
     public bool WeakPush(FSMUnit state)
     {
		if (state.Priority>CurState.Priority)
		{
		    list.Insert(0,state);
		    return true;
		}	
		return false;

     }
     
     public bool StrongPush(FSMUnit state)
     {
		 if (state.Priority>CurState.Priority)
		 {
	        list.Insert(0,state);
		    return true;
		 }
         else
		 {
		    list.Insert(1,state);
		    return false;
		 }
     }

     public bool Replace(FSMUnit state)
     {
		if (state.Priority>=CurState.Priority)
		{
			if(list[0].Priority==FSMPRIORITYTYPE.NONE)
			{
				 list.Insert(0,state);
			}
			else
			{
				list[0]=state;
			}
		    return true;
		}
		return false;
	
     }
    
     public bool Run()
     {	
     	if(m_lastState!=CurState)
     	{
     		CurState.Update();
     		m_lastState = CurState;
     	}

     	if(CurState.Run())
		{	
		    list.RemoveAt(0);
		}

        return true;		
     }
}
