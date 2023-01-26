using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toxicZone : MonoBehaviour
{

    private bool _playerInRange;
    playerFilter filter;
    PlayerHealth health;
    [SerializeField]private GameObject vcam;
    [SerializeField]private GameObject tcam;
    private Coroutine toxicAttack;
    private Coroutine filterDrain;
    [SerializeField] private float _drain;
    [SerializeField] private float _attack;
    private bool _geigerAudio;

    void Start()
    {
        _playerInRange = false;
        _geigerAudio = false;
    }

    void Update (){




        if (_playerInRange)
        {


            if (!_geigerAudio)
            {
                _geigerAudio = true;
                AudioManager.instance.Play("Geiger");
            }
            if (filterDrain== null){
                filterDrain = StartCoroutine (FilterDrain());
            } 
            if (GameManagement.manager.filterLife <= 0 && toxicAttack == null && GameManagement.manager.playerHealth > 0){
                toxicAttack = StartCoroutine (ToxicAttack());
            }
        }
        else {
            StopCoroutine(FilterDrain());
            StopCoroutine(ToxicAttack());
        }


        if (GameManagement.manager.playerHealth <= 0)
        {
           
            _playerInRange=false;
        }


        if (_geigerAudio && !_playerInRange)
        {
            _geigerAudio = false;
            AudioManager.instance.Stop("Geiger");
            Debug.Log("Stop Geiger Audio");
        }

    }


    IEnumerator FilterDrain(){
		while (_playerInRange){
			filter.UpdateFilter(-_drain);
			yield return new WaitForSeconds (.5f);
		}
		filterDrain = null;
	 }

    	IEnumerator ToxicAttack(){
		while (_playerInRange){
			health.UpdateHealth(-_attack);
			yield return new WaitForSeconds (.5f);
		}
		toxicAttack = null;
		

	}


    void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Debug.Log("Toxic Ouchie!");
            tcam.SetActive(true);
            vcam.SetActive(false);
			_playerInRange = true;
            GameManagement.manager.toxic = true;
		    filter = collider.gameObject.GetComponent<playerFilter>();
            health = collider.gameObject.GetComponent<PlayerHealth>();
	
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == "Player"){
			Debug.Log("No more Toxic Ouchie!");
            vcam.SetActive(true);
            tcam.SetActive(false);
			_playerInRange = false;
            GameManagement.manager.toxic = false;
		    filter= null;
            health= null;
	
	
		}
    }
}
