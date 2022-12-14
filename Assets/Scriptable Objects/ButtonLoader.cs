using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoader : MonoBehaviour
{
[SerializeField] private LevelConnection _connection;



[SerializeField]
private string _targetSceneName;




public void ClickLoader(){
    LevelConnection.ActiveConnection = _connection;
                SceneManager.LoadScene(_targetSceneName, LoadSceneMode.Single);
}



}
