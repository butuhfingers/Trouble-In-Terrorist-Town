using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour{

	//Variables
	private ICameraSetup cameraSetup;

	//Properties
	public ICameraSetup CameraSetup{
		get { return cameraSetup; }
	}

	// Use this for initialization
	public void Initialize (ICameraSetup cameraSetup) {
		this.cameraSetup = cameraSetup;
	}
}
