
using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 30;
	public int curHealth = 30;
	public bool isSelected;

	public float healthBarLength;
	//public static bool isSelected = false;
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth(0);

	}

	
	public void AddjustCurrentHealth(int adj) {
		curHealth += adj;
		
		if(curHealth < 0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth < 1)
			maxHealth = 1;

		if(curHealth == 0)
			//destroy game object
			Destroy (gameObject);
		
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
	void OnGUI(){
		if(isSelected){
		GUI.Box(new Rect(10, 40, healthBarLength, 20), curHealth + "/" + maxHealth);
		}
		}
}