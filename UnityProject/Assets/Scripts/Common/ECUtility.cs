using UnityEngine;
using System.Collections;

public class ECUtility  {

	public static float GetSupportTerrainHeight(Vector3 vPos,float fRadius=0)
	{	
		Vector3 temp = vPos;
		temp.y=temp.y+30;
		return GetSupportPlaneHeight(temp,LayerMask.GetMask("Terrain"),fRadius);
	}

	
	public static float GetSupportPlaneHeight(Vector3 vPos,int mask,float fRadius=0)
	{
		RaycastHit hitInfo;
		bool bRet=(fRadius==0)?Physics.Raycast(vPos,Vector3.down,out hitInfo, vPos.y+50,mask):Physics.SphereCast(vPos,fRadius, Vector3.down,out hitInfo, vPos.y+500,mask);
		return bRet?hitInfo.point.y:0;
	}
}
