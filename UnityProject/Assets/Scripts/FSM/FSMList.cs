using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FSMList{
     List<FSMUnit> list = new List<FSMUnit>();
     public FSMUnit CurState
     {
	    get{return list[0];}
     }
     void Init()
     {
		 list.Add(FSMUnit.FSMNullState);
     }
     public FSMList()
     {
	    Init();
     }
     public bool WeakPush(FSMUnit state)
     {
		if (state.Priority>=CurState.Priority)
		{
		    list.Insert(0,state);
		    return true;
		}	
		return false;

     }
     
     public bool StrongPush(FSMUnit state)
     {
		 if (state.Priority>=CurState.Priority)
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
		    list[0]=state;
		    return true;
		}
		return false;
	
     }
    
     public bool Run()
     {
		if(!CurState.Run())
		{
		  if(list.Count==1)
		  {
		     list[0]=FSMUnit.FSMNullState;
		  }
		  else
		  {
			  
		     list.RemoveAt(0);
		  }
		 
		}

        return true;		
     }
}
