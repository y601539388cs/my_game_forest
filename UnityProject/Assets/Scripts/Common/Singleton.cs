using UnityEngine;
using System.Collections;

public class Singleton<T>  {



	public static T Instance = System.Activator.CreateInstance<T>();

	
}
