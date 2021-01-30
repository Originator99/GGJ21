using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PortalSceneController : MonoBehaviour
{
    private void Start()
    {
        PortalNumber portal = (PortalNumber)Random.Range(0, 5);
        PortalInfo portalInfo = new PortalInfo(portal);
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.PLAY_HELP_AUDIO, portalInfo);
    }
}
