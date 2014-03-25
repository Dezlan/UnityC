using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {
	
	void Start () {
		MovieTexture movie = renderer.material.mainTexture as MovieTexture;
		
		movie.Play ();

		Invoke("load", 11);
	
		
	}

	void load(){
		Application.LoadLevel ("menu");
	}

}