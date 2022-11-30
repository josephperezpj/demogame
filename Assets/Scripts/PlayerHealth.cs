using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   public HealthBar healthBar;
   public Animator animator;

   void Start (){
    	
        animator = GetComponent<Animator>();
   }

   public void UpdateHealth(float mod)
	{

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
		
	}
}
