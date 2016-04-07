using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCoordinate {



	public Vector3 RootPos;
	public Vector3 LeftRightPos;
    public int Width = 100;
    public int Hight = 100;
    public WorldCoordinateUnit [,] InfoMap;
    private WorldCoordinate()
    {
    	InfoMap =  new  WorldCoordinateUnit[Width,Hight];
    }
    

    public static WorldCoordinate Instance = new WorldCoordinate();


    

    
}
