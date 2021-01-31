using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public LevelLoad levelLoader;


    private void Start() {
        GameEventSystem.GameEventHandler += HandleGameEvents;
        GameStart();
    }

    private void OnDestroy() {
        GameEventSystem.GameEventHandler -= HandleGameEvents;
    }

    private void HandleGameEvents(EVENT_TYPE type, object data) {
        if(type == EVENT_TYPE.LOAD_LEVEL && data != null && data.GetType() == typeof(int)) {
            OnNewLevelLoad((int)data);
        }
        if(type == EVENT_TYPE.ENEMY_KILLED) {
            ScoreManager.OnEnemyKilled();
        }
    }

    private void GameStart() {
        ScoreManager.ResetScore();
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.LOAD_LEVEL, 0);
    }

    private void OnNewLevelLoad(int id) {
        levelLoader.PlaceLevel(id);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameStart();
        }
    }
}
