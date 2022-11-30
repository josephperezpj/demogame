using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{
	[SerializeField]private float attackDamage = 25;
	[SerializeField]private bool isDamaging = false;
	PlayerHealth playerhealth;
	 private Coroutine hazardAttack;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Debug.Log("Ouchie!");
			isDamaging = true;
		    playerhealth = collider.gameObject.GetComponent<PlayerHealth>();
	
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			Debug.Log("No more Ouchie!");
			isDamaging = false;
		    playerhealth = null;
			StopCoroutine (dealDamage());
	
		}
	}
	void Update (){
		if(hazardAttack == null && GameManagement.manager.playerHealth > 0){
			hazardAttack = StartCoroutine (dealDamage());
		}

		if(GameManagement.manager.playerHealth <= 0)	{
			isDamaging = false;
			StopCoroutine (dealDamage());
		}
			
		
	}

	IEnumerator dealDamage(){
		while (isDamaging){
			Debug.Log("hazard trigger");
			playerhealth.UpdateHealth(-attackDamage);
			yield return new WaitForSeconds (.5f);
		}
		hazardAttack = null;
		

	}
}
