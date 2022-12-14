using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
[SerializeField] private LevelConnection _connection;
[SerializeField] private GameObject visualCue;


[SerializeField]
GameObject Player;
[SerializeField]
private string _targetSceneName;
[SerializeField]
private Transform _spawnPoint;
private bool playerInRange;



    private void Start (){
        if (_connection == LevelConnection.ActiveConnection){
            Player.transform.position = _spawnPoint.position;
        }
    }

    private void Update(){

        if (playerInRange){

            visualCue.SetActive(true);
             if (Input.GetKeyDown("e")){
        
                LevelConnection.ActiveConnection = _connection;
                SceneManager.LoadScene(_targetSceneName, LoadSceneMode.Single);
             }
        }
        else{
                visualCue.SetActive(false);
        }
    } 

private void ClickLoader(){
    LevelConnection.ActiveConnection = _connection;
                SceneManager.LoadScene(_targetSceneName, LoadSceneMode.Single);
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
