
using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	public float attackTimer;
	public float coolDown;


	void Start () {
		attackTimer = 0;
		coolDown = 1.0f;
	}
	

	void Update () {
		if(attackTimer > 0)
			attackTimer -= Time.deltaTime;
		
		if(attackTimer < 0)
			attackTimer = 0;
		
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown ("joystick 1 button 5")){
			if(attackTimer == 0) {
				Attack();
				attackTimer = coolDown;
			}
			
		}
	}
		
	
	
	
	private void Attack() {
		float distance = Vector3.Distance(target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot(dir, transform.forward);
		
		if(distance < 10f) {
			if(direction > 0) {
				EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");
				eh.AddjustCurrentHealth(-10);
			}
		}
	}
}
