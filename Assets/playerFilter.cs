using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFilter : MonoBehaviour
{

   public FilterBar filterBar;
   public PlayerHealth player;

    void Start (){
       
    }




    public void UpdateFilter (float mod){
        GameManagement.manager.filterLife +=mod;

        filterBar.SetFilter(GameManagement.manager.filterLife);

        if (GameManagement.manager.filterLife >= GameManagement.manager.filterMax){
			GameManagement.manager.filterLife = GameManagement.manager.filterMax;
        }
        
         if (GameManagement.manager.filterLife <= 0){
			GameManagement.manager.filterLife = 0;
        }

    }
}
