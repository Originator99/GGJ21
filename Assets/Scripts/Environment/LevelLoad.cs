using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoad : MonoBehaviour {
    public PortalSceneController portalsController;

    public GameObject player;

    public GameObject[] levels;

    private GameObject currentLevel;

    private void Start() {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlaceLevel(int id) {
        GameObject level = GetLevel(id);
        if(level != null) {
            player.SetActive(false);
            if(currentLevel != null) {
                Destroy(currentLevel);
            }
            currentLevel = Instantiate(level, new Vector3(0, 0, 0), Quaternion.identity);
            currentLevel.transform.SetAsFirstSibling();
            currentLevel.gameObject.SetActive(true);
            OnLevelLoaded(currentLevel.GetComponent<EnvironmentDataHolder>());
        } else {
            Debug.LogError("Level is Null");
        }
    }

    private GameObject GetLevel(int level_id) {
        if(level_id < levels.Length) {
            switch(level_id) {
                case 0:
                    return levels[0];
                case 1:
                    return levels[1];
                case 2:
                    return levels[2];
                case 3:
                    return levels[3];
                default:
                    return null;
            }
        }
        return null;
    }

    private void OnLevelLoaded(EnvironmentDataHolder data) {
        if(data != null) {
            if(data.levelID == 0) {
                ScoreManager.GenerateSitaPortal();
            }

            player.SetActive(true);
            data.PlacePlayer(player);
            portalsController.SetLevelPortalOrSita(data.GetLevelPortals(), data.GetSitaCage(), data.levelID);
        } else {
            Debug.LogError("Data holder is null");
        }
    }
}
