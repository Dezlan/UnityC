using UnityEngine;
using System.Collections;

public class loading : MonoBehaviour {
	
	void Start () {

		load ();
		
		
	}
	
	void load(){
		Application.LoadLevel ("main");
	}
	
}