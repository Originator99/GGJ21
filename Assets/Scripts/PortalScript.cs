using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public PortalNumber portalNumber;

    public AudioSource helpAudioSource;

    public BoxCollider boxCollider;

    private void Start()
    {
        GameEventSystem.GameEventHandler += HandleEvents;
    }

    private void OnDestroy()
    {
        GameEventSystem.GameEventHandler -= HandleEvents;
    }

    private void OnDisable()
    {
        GameEventSystem.GameEventHandler -= HandleEvents;
    }

    private void HandleEvents(EVENT_TYPE type, System.Object data = null)
    {
        if(type == EVENT_TYPE.PLAY_HELP_AUDIO)
        {
            CheckAndPlayActivatePortal(data as PortalInfo);
        }
    }

    private void CheckAndPlayActivatePortal(PortalInfo portalInfo)
    {
        if(portalInfo.portalNumber == portalNumber)
        {
            helpAudioSource.Play();
            boxCollider.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.CompareTag("Player"))
        {
            LoadLevelScene();
        }
    }

    private void LoadLevelScene()
    {
        SceneManager.LoadScene("Level" + (int)portalNumber);
    }
}

public class PortalInfo
{
    public PortalNumber portalNumber;

    public PortalInfo(PortalNumber portal)
    {
        portalNumber = portal;
    }
}

public enum PortalNumber
{
    One,
    Two,
    Three,
    Four,
    Five
}