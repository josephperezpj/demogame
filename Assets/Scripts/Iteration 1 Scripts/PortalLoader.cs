using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLoader : MonoBehaviour
{
    
    [SerializeField] private GameObject visualCue;
    public bool playerInRange;
    public string LevelName;

    private void Start (){
         visualCue.SetActive(false);
    }


    private void Update(){

        if (playerInRange){

             visualCue.SetActive(true);

             if (Input.GetKeyDown("e")){
                SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
             }
        }
        else{
            visualCue.SetActive(false);
        }
    } 



     private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
