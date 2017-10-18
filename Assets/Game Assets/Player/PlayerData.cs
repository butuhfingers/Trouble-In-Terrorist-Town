using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData{
	//Constructor
	public PlayerData(){
		this.playerName = "[Player Name]";
		this.movementSpeed = 5.0f;
		this.movementAmplifier = 2.0f;
		this.rotationSpeed = 50.0f;
		this.rotationSensitivity = 2.0f;
	}

	//Variables
	protected string playerName;
	protected float movementSpeed;
	protected float movementAmplifier;
	protected float rotationSpeed;
	[Range(0.0f, 10.0f)]protected float rotationSensitivity;

	//Properties
	public string PlayerName{
		get{ return this.playerName; }
		set{ this.playerName = value; }
	}

	//Movement speed variables
	public float MovementSpeed{
		get{return this.movementSpeed;}
	}
	public float MovementAmplifier{
		get{return this.movementAmplifier;}
	}

	//Rotation speed variables
	public float RotationSpeed{
		get{return this.rotationSpeed;}
	}
	public float RotationSensitivity{
		get{return this.RotationSensitivity;}
	}
}
