using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBase : NetworkBehaviour {
	//Variables
	[SyncVar]
	private string playerName;
	private PlayerData playerData;
	private GameObject playerNameText;
	public string PlayerNameTextName{get {return "Player Name";}}	//Get the name of the player name text object
	private GameObject playerModel;
	public string PlayerModelName{get{return "Player Model";}}	//Get the name of the player model object
	private PlayerNetworker playerNetworkerScript;
	private PlayerMove playerMoveScript;	//Only set if we are the localhost
	private PlayerCamera playerCameraScript;	//Only set if we are the localhost
	private Camera mainCamera;

	//Properties
	//Player name
	public string PlayerName{
		get{
			return PlayerInformation.PlayerName;
		}
		private set{
			PlayerInformation.PlayerName = value;
			playerName = value;

			//Change the name on the text mesh too
			playerNameText.GetComponent<TextMesh>().text = value;
		}
	}
	public PlayerData PlayerInformation{
		get{
			return this.playerData;
		}
	}
	public PlayerMove PlayerMoveScript{
		get{ return this.playerMoveScript; }
	}
	public PlayerCamera PlayerCameraScript{
		get{ return this.playerCameraScript; }
	}


	//Player name text properties
	public GameObject PlayerNameText{
		get{
			return this.playerNameText;
		}
	}

	//Player model properties
	public GameObject PlayerModel{
		get{
			return this.playerModel;
		}
	}

	// Use this for initialization
	void Start () {
		//We need to create a stats sheet for our player
		playerData = PlayerDataMode.Normal;

		//We need to find our compononents attached to the player
		playerNameText = ChildFinder.FindChildByName(transform, PlayerNameTextName).gameObject;
		PlayerName = PlayerInformation.PlayerName;	//Set the player name
		playerModel = ChildFinder.FindChildByName(transform, PlayerModelName).gameObject;
		mainCamera = FindMainCamera();

		//Add our components and put them on our variables
		playerNetworkerScript = gameObject.AddComponent<PlayerNetworker>();

		//We need to check if we are a network player before adding these
		if(playerNetworkerScript.IsLocalPlayer){
			//Add this to our player
			playerCameraScript = new PlayerCamera(CameraSetupMode.Murder, FindMainCamera(), this);
			playerMoveScript = new PlayerMove(this);
		}
	}


	void Update(){
		//We need to face the player names to the player camera
		playerNameText.transform.LookAt((2 * PlayerNameText.transform.position) - mainCamera.transform.position);
		PlayerName = PlayerInformation.PlayerName;

		//Everything below this if for the local player
		if(!playerNetworkerScript.IsLocalPlayer)
			return;

		//Update our player's camera position
		playerCameraScript.UpdatePosition();
		playerMoveScript.UpdatePosition();
	}


	//We need to find the main camera in the scene
	private Camera FindMainCamera(){
		//If we are the local player, check our heirarchy
		//If not, check the tags
		return GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}

	//We need to change the player name
	[Command]
	private void CmdChangePlayerName(string nameToChangeTo){
		this.PlayerName = nameToChangeTo;
	}


	private void OnGUI(){
		if(playerNetworkerScript.IsLocalPlayer){
			string tempPlayerName = PlayerName;
			tempPlayerName = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), tempPlayerName);

			if(tempPlayerName != this.PlayerName){
				PlayerName = tempPlayerName;
				CmdChangePlayerName(tempPlayerName);
			}
		}
	}
}
