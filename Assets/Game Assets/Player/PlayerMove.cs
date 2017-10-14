using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : MonoBehaviour {
	//Variables
	private float moveSpeed = 3.0f;
	private PlayerNetworker objectNetwork;

	//Properties
	public float MoveSpeed{
		get{
			return moveSpeed;
		}private set{
			moveSpeed = value;
		}
	}
	public PlayerNetworker ObjectNetwork{
		get{
			//Check if the player networker is attached

			return GetComponent<PlayerNetworker>();
		}
	}



	// Use this for initialization
	void Start () {
		//do nothing
	}
	
	// Update is called once per frame
	void Update () {
		//Check if we are not a local player
/*		if(!ObjectNetwork.IsLocalPlayer){
			//Do not continue otherwise
			return;
		}
*/
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * MoveSpeed;

		transform.Translate(move);
	}
}
