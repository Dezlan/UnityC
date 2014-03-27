var btnTexture : Texture;
var btnTexture2 : Texture;
var btnTexture3 : Texture;
var btnTexture4 : Texture;
var btnTexture5 : Texture;


	function OnGUI() {
		if (!btnTexture) {
			Debug.LogError("Please assign a texture on the inspector");
			return;
		}
		if (GUI.Button(Rect(10,500,100,50),btnTexture))
			 Application.LoadLevel("loading");
		if (GUI.Button(Rect(110,500,100,50),btnTexture2))
			Debug.Log("Clicked the button with an image");
		if (GUI.Button(Rect(210,500,100,50),btnTexture3))
			Debug.Log("Clicked the button with an image");
		if (GUI.Button(Rect(310,500,100,50),btnTexture4))
			Debug.Log("Clicked the button with an image");
		if (GUI.Button(Rect (Screen.width/2-100, Screen.height/2-300, 300, 100),btnTexture5));
			Debug.Log("Clicked the button with an image");
	}