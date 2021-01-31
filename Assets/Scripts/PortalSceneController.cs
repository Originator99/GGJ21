using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PortalSceneController :MonoBehaviour {
    //sita control
    //portal level control

    public void SetLevelPortalOrSita(PortalDataHolder[] levelPortal, GameObject levelSita, int levelId) {
        if(levelId == 0) {
            if(levelPortal != null) {
                foreach(var tem in levelPortal) {
                    if(tem.controller != null) {
                        tem.controller.ActivatePortal(tem.redirectsToLevel);
                    }
                }
            }
        } else {
        }
        if(levelPortal != null) {
            
        }
    }
}
