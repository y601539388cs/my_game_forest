using UnityEngine; 
using System.Collections;
using System.Collections.Generic;

public class FSMUnit_MultiBase
{
	public virtual bool Run()
	{
		return true;
	}
}
public class FSMUnit_Multi:FSMUnit  {
	
	public FSMUnit_Multi(){}
	public FSMUnit_Multi(FSMPRIORITYTYPE priority)
	{
	    this.Priority= priority;
	}

	//multiTask excute at the same time
	LinkedList<FSMUnit_MultiBase> list = new LinkedList<FSMUnit_MultiBase>();
	public void AddBaseUnit(FSMUnit_MultiBase fmbu)
	{	
		list.AddLast(fmbu);
	}
	public virtual bool Run(){
		LinkedListNode<FSMUnit_MultiBase> temp=list.First;
		LinkedListNode<FSMUnit_MultiBase> next=temp; 
		bool reValue = true;
		if(temp!=null)
		{
			bool result = temp.Value.Run();
			next = temp.Next;
			if(result)
			{
				list.Remove(temp);
			}
			temp = next;
			reValue=reValue&&result;
		}
		return reValue;
	}
}
