public static class CameraSetupMode{
	//Properties
	public static ICameraSetup HideNSeek{
		get{return new BaseCameraSetup(); }
	}

	public static ICameraSetup Murder{
		get{return new MurderCameraSetup(); }
	}

	public static ICameraSetup PropHunt{
		get{return new BaseCameraSetup(); }
	}

	public static ICameraSetup TTT{
		get{return new BaseCameraSetup(); }
	}
}
