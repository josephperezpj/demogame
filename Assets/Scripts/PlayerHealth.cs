using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public HealthBar healthBar;
   public Animator animator;
	[SerializeField] SpriteRenderer spriteRenderer;
	public float _damageTimer = 1.0f;

   void Start (){
    	
        animator = GetComponent<Animator>();
   }

   public void UpdateHealth(float mod)
	{
		Debug.Log("Update Player Health");
		GameManagement.manager.playerHealth  += mod;
		
		healthBar.SetHealth(GameManagement.manager.playerHealth);
		
		if (GameManagement.manager.playerHealth <= 0){
			animator.SetTrigger("isDead");
        }
		else if (GameManagement.manager.playerHealth >= GameManagement.manager.playerMaxHealth){
			GameManagement.manager.playerHealth = GameManagement.manager.playerMaxHealth;
        }

        if (GameManagement.manager.playerHealth <=0){
            GameManagement.manager.Death();
        }

		if ( mod < 0)
        {
			AudioManager.instance.Play("Hurt");
			Debug.Log("Play hurt audio");
			

		}
		
	}

}
