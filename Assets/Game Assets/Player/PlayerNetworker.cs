using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworker : NetworkBehaviour {
	//Properties
	public bool IsLocalPlayer{
		get{
			return isLocalPlayer;
		}
	}

	private void Start(){
		
	}
}
