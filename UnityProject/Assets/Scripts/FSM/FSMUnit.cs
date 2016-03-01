using UnityEngine; 
using System.Collections;


public enum FSMPRIORITYTYPE //所有的FSM优先级都在这里定义,每一个类应该有这张表并且具有继承关系
{
   NONE = 0,
   NORMAL=1,
   ACTION_MOVE=2,
}

public class FSMUnit  {
	FSMPRIORITYTYPE priority=FSMPRIORITYTYPE.NORMAL;
	protected string FSMType = "base";
    public static  FSMUnit FSMNullState= new FSMUnit(FSMPRIORITYTYPE.NONE);
	
	public delegate void RunHandlerDelegate();
	protected RunHandlerDelegate m_runHandle;

	public FSMPRIORITYTYPE Priority
	{ 
	  get
	  {
		return priority;
	  }
	  set
	  {
		 priority=value;
	  }
	}
	
	public FSMUnit(){}
	public FSMUnit(FSMPRIORITYTYPE priority)
	{
	    this.Priority= priority;
	}
	public virtual bool Run(){return true;}
		
}
