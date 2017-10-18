using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour{
	//Constructor
	public PlayerCamera (ICameraSetup cameraSetup, Camera playerCamera, PlayerBase player) {
		//Set our camera setup variable
		this.cameraSetup = cameraSetup;
		this.playersFocusCamera = playerCamera;
		this.player = player;
	
		PlayerFocusCamera.transform.rotation = player.transform.rotation;
		PlayerFocusCamera.transform.parent = player.transform;
		Cursor.lockState = CursorLockMode.Locked;
	}

	//Variables
	private ICameraSetup cameraSetup;
	private Camera playersFocusCamera;
	private PlayerBase player;

	//Properties
	public ICameraSetup CameraSetup{
		get { return cameraSetup; }
	}

	public Camera PlayerFocusCamera{
		get{ return playersFocusCamera; }
	}

	//We need to update the camera position
	public void UpdatePosition(){
		//Move the camera to the position
		PlayerFocusCamera.transform.position = player.transform.position + cameraSetup.Position;

		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Time.deltaTime * player.PlayerMoveScript.RotationSpeed * player.PlayerMoveScript.Sensitivity;

		PlayerFocusCamera.transform.Rotate(-mouseMovement.y, 0, 0);
	}
}
