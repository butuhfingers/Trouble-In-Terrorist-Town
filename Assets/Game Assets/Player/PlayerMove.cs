using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviour {
	//Constructor
	public PlayerMove(PlayerBase player){
		this.player = player;
	}

	//Variables
	private PlayerBase player;
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
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * MoveSpeed * moveSpeedAmplifer;
		Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * Time.deltaTime * RotationSpeed * sensitivity;

		player.transform.Translate(move);
		player.transform.Rotate(0, mouseMovement.x, 0);
	}
}
