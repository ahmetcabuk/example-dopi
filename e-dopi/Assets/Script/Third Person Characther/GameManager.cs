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

    public void RestartLevel()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance.fail);
        Vector3 restartPosition = new Vector3(0, 0, 0);
        _player.transform.position = restartPosition;
    }
}
