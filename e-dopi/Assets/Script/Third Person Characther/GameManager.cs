using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameObject _player;
    
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    //private IEnumerator RestartLevel()
    //{

    //    //yield return WaitUntil(() => ;

    //    Vector3 restartPosition = new Vector3(0, 0, 0);
    //    player.transform.position = restartPosition;
    //}

    public void RestartLevel()
    {
        Vector3 restartPosition = new Vector3(0, 0, 0);
        _player.transform.position = restartPosition;
    }
}
