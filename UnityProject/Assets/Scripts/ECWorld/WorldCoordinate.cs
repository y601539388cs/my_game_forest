using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldCoordinate {

public:
	Vector3 RootPos = null;
	Vector3 LeftRightPos= null;
    int Width = 100;
    int Hight = 100;

    WorldCoordinateUnit InfoMap[,] = new WorldCoordinateUnit[Width,Hight];


}
