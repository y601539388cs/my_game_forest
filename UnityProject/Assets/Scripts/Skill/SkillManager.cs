using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager {

	public static SkillManager Instance = new SkillManager();
	
	private WorldCoordinate world_cord = WorldCoordinate.Instance;

	private ArrayList  m_curSkillList = new ArrayList();
	public void GetSkillHurt()
    {
    	for(int i=0;i<world_cord.Hight;++i)
    	{
    		for(int j=0;j<world_cord.Width;++j)
    		{
    			
    			world_cord.InfoMap[j,i].GetSkillHurt();	
    		}
    	}
    }

    public int AddSkill(Skill s)
    {
    	return m_curSkillList.add(s);
    }

    public void RemoveSkill (int index)
    {
        m_curSkillList.RemoveAt(index);
    }
    public void GetHurtUnit()
    {
       for(int i=0;i<m_curSkillList.Count;++i)
        {
            m_curSkillList[i].GetHurtUnit();
        } 
    }
    public void GetCollideResult()
    {
    	for(int i=0;i<world_cord.Hight;++i)
        {
            for(int j=0;j<world_cord.Width;++j)
            {
                
                world_cord.InfoMap[j,i].GetCollideResult(); 
            }
        }
    }

    public void FreshSkillScope()
    {
       for(int i=0;i<m_curSkillList.Count;++i)
        {
            m_curSkillList[i].FreshSkillScope();
        }  
    }
    public void FreshAttack()
    {
        FreshSkillScope();
        GetSkillHurt();
        GetHurtUnit();
        GetCollideResult();
    }
}

   
