using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCameraSetup : MonoBehaviour, ICameraSetup {
	//Constructor
	public BaseCameraSetup(float x, float y, float z){
		startCameraPosition = new Vector3(x, y, z);
	}
	public BaseCameraSetup() : this(0, 0, 0){}	//Call the constructor the sets the x, y, z coordinates

	//Variables
	protected Vector3 startCameraPosition;

	//Properties
	public float X{
		get{return startCameraPosition.x;}
	}
	public float Y{
		get{return startCameraPosition.y;}
	}

	public float Z{
		get{return startCameraPosition.z;}
	}

	public Vector3 Position{
		get{ return startCameraPosition; }
	}
}
