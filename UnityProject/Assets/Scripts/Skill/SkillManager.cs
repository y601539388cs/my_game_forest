﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager {

	public static SkillManager Instance = new SkillManager();
	
    public WorldTest m_worldTest;
	private WorldCoordinate world_cord = WorldCoordinate.Instance;
    
	private List<Skill>  m_curSkillList = new List<Skill>();
	public void GetSkillHurt()
    {
    	for(int i=0;i<world_cord.Height;++i)
    	{
    		for(int j=0;j<world_cord.Width;++j)
    		{
    			
    			world_cord.InfoMap[j,i].GetSkillHurt();	
    		}
    	}
    }

    public int AddSkill(Skill s)
    {   
        int index = m_curSkillList.Count;
        m_curSkillList.Add(s);
    	return index;
    }

    public void RemoveSkill (int index)
    {
        m_curSkillList[index]=SkillNone.Instance;
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
    	for(int i=0;i<world_cord.Height;++i)
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

    public void Run()
    {
        for(int i=0;i<m_curSkillList.Count;++i)
        {
            m_curSkillList[i].Run();
        } 
    }
    public void Clear()
    {
        for(int i=0;i<world_cord.Height;++i)
        {
            for(int j=0;j<world_cord.Width;++j)
            {
                
                world_cord.InfoMap[j,i].Clear(); 

            }
        }

        for(int i=0;i<m_curSkillList.Count;++i)
        {
            m_curSkillList[i].Clear();
        }

        m_worldTest.Clear();
    }

   
    public void FreshAttack()
    {
        Clear();
        FreshSkillScope();
        GetSkillHurt();
        GetHurtUnit();
        GetCollideResult();
    }
}

   
