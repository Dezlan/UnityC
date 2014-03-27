
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	//targets holds all enemies with tha tag enemy.
	public List<Transform> targets;
	//inrange looks through the targets array to find those targets within 20 metres and allows them to be added to selectedTarget
	public List<Transform> inrange;
	//selectedTarget holds the transform of the currently selected target in the inrange list
	public Transform selectedTarget;

	//holds the transform value of the....player?
	private Transform myTransform;





		
	// Use this for initialization
	void Start () {
		targets = new List<Transform>();
		selectedTarget = null;
		myTransform = transform;

		AddAllEnemies();
	}
	
	public void AddAllEnemies() {
		GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
		
		foreach(GameObject enemy in go)
			AddTarget(enemy.transform);
	}
	
	public void AddTarget(Transform enemy) {
		targets.Add(enemy);
	}
	
	
	private void SortTargetsByDistance() {
		targets.Sort(delegate(Transform t1, Transform t2) {
				return Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position));
				});
	}
	
	
	//if we do not have an enemy targeted ywt, then find the clostest one and target him
	//if we do have an enemy targeted, then get the next target
	//if we have the last target in the list, then get then first target in the list
	private void TargetEnemy() {

	

		if(targets.Count==0)
		{
			//do nothing, remains empty
			//Debug.Log("Nothing in range");
		}
		else
		{
		

		if(selectedTarget == null) {
			SortTargetsByDistance();
			//select the first in targets, which has been sorted by distance
			selectedTarget = inrange[0];
		}
		else {
			int index = inrange.IndexOf(selectedTarget);


			if(index < inrange.Count - 1) {
				//move forward once in the array
				index++;
			}
			else {
				//index of array, 0- back to start
				index = 0;
			}
			DeselectTarget();
			selectedTarget = inrange[index];
		}
		SelectTarget();
		}
	}
	
	private void SelectTarget() {
		selectedTarget.renderer.material.color = Color.red;



		selectedTarget.GetComponent< EnemyHealth>().isSelected = true;


		PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");

		pa.target = selectedTarget.gameObject;
	}
	
	private void DeselectTarget() {
		selectedTarget.renderer.material.color = Color.white;
		selectedTarget.GetComponent< EnemyHealth>().isSelected = false;
		selectedTarget = null;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown ("joystick 1 button 4")) {
			updateInRange();
			TargetEnemy();

		}
	}

	private void updateInRange(){
	//clear the inrange array, prepare for next use
		inrange.Clear();
	//loop through targets, looking for in range
		for(int i=0; i<targets.Count; i++){

			//Debug.Log(targets[i].transform);

			if(targets[i] == null){
				targets.RemoveAt(i);
			}

			float distance = Vector3.Distance(myTransform.position,targets[i].transform.position);



				if (distance < 50f){
				
				print ("Something in range");
				//add to list


				inrange.Add(targets[i]);
				Debug.Log (inrange);

		}
		}

}
}
