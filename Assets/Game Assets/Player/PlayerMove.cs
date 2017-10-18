using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviour {
	//Constructor
	public PlayerMove(PlayerBase player){
		this.playerBase = player;
	}

	//Variables
	private PlayerBase playerBase;
	private float moveSpeed = 5.0f;
	private float moveSpeedAmplifer = 2.0f;
	private float rotationSpeed = 50.0f;
	[Range(0.0f, 10.0f)]private float sensitivity = 2.0f;
	private PlayerNetworker objectNetwork;

	//Properties
	public float MoveSpeed{
		get{
			return moveSpeed;
		}private set{
			moveSpeed = value;
		}
	}
	public float RotationSpeed{
		get { return rotationSpeed; }
	}
	public float Sensitivity{
		get{ return sensitivity; }
	}

	public PlayerNetworker ObjectNetwork{
		get{
			//Check if the player networker is attached

			return GetComponent<PlayerNetworker>();
		}
	}
	
	// Update is called once per frame
	public void UpdatePosition () {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * playerBase.PlayerInformation.MovementSpeed * playerBase.PlayerInformation.MovementAmplifier;
		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Time.deltaTime * RotationSpeed * sensitivity;

		playerBase.transform.Translate(move);
		playerBase.transform.Rotate(0, mouseMovement.x, 0);
	}
}
