﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCoordinate {



	public Vector3 RootPos;
	public Vector3 LeftRightPos;
    public int Width = 100;
    public int Height = 50;
    public WorldCoordinateUnit [,] InfoMap;
    
    private WorldCoordinate()
    {

    	InfoMap =  new  WorldCoordinateUnit[Width,Height];
        for(int i=0;i<Width;++i)
        {
            for(int j=0;j<Height;++j)
            {
                InfoMap[i,j]=new WorldCoordinateUnit();
            }
        }

      
            


    }
    

    public static WorldCoordinate Instance = new WorldCoordinate();

    public void AddSkill(int i,int j,Skill s)
    {
    	if(i>=0 && i<Width && j>=0 &&j<Height)
    	{
    		InfoMap[i,j].AddSkill(s);
            SkillManager.Instance.m_worldTest.SetGridColor(i,j,Color.red);
    	}
    	
    }
    

    
}
