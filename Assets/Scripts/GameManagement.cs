using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement manager;
    public float playerMaxHealth = 100;
    public float playerHealth;
    public float filterLife;
    public float filterMax = 100;


    void Awake(){
        if (manager == null){
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager !=this){
            Destroy(gameObject);
        }
     playerHealth = playerMaxHealth;
     filterMax = 100;
     filterLife = filterMax;

    }


   public event Action onDeathTrigger;
   
    public void Death()  {
        if (onDeathTrigger != null){
            onDeathTrigger();
        }

        Debug.Log("Dead.");
    }
}
