using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	void Start () {
		MovieTexture movie = renderer.material.mainTexture as MovieTexture;
	
		movie.Play ();




	}

}