using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCoordinate {



	public Vector3 RootPos = null;
	public Vector3 LeftRightPos= null;
    public int Width = 100;
    public int Hight = 100;

    public WorldCoordinateUnit InfoMap[,] = new WorldCoordinateUnit[Width,Hight];

    public static WorldCoordinate Instance = new WorldCoordinate();


    

    
}
