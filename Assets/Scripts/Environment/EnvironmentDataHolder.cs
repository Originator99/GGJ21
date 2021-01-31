using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnvironmentDataHolder : MonoBehaviour {
    public int levelID;

    [SerializeField]
    private Transform playerStartPosition;
    [SerializeField]
    private PortalDataHolder[] portals;
    [SerializeField]
    private GameObject sitaCage;

    public void PlacePlayer(GameObject player) {
        player.transform.position = playerStartPosition.position;
        player.transform.rotation = playerStartPosition.rotation;
    }

    public PortalDataHolder[] GetLevelPortals() {
        return portals;
    }
    public GameObject GetSitaCage() {
        return sitaCage;
    }
}

[System.Serializable]
public class PortalDataHolder {
    public PortalScript controller;
    public int redirectsToLevel;
}