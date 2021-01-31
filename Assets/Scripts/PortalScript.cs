using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript :MonoBehaviour {

    public AudioSource helpAudioSource;

    public BoxCollider boxCollider;

    private int redirectionLevelID;


    private void Start() {
        GameEventSystem.GameEventHandler += HandleEvents;
    }

    private void OnDestroy() {
        GameEventSystem.GameEventHandler -= HandleEvents;
    }

    private void OnDisable() {
        GameEventSystem.GameEventHandler -= HandleEvents;
    }

    private void HandleEvents(EVENT_TYPE type, System.Object data = null) {
    }

    public void ActivatePortal(int redirectionLevelID) {
        this.redirectionLevelID = redirectionLevelID;
        CheckAndPlayActivatePortal();
        gameObject.SetActive(true);
    }

    private void CheckAndPlayActivatePortal() {
        if(ScoreManager.IsSitaPortal(redirectionLevelID)) {
            helpAudioSource.Play();
        } else {
            
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger");
        if(other.CompareTag("Player")) {
            LoadLevelScene();
        }
    }

    private void LoadLevelScene() {
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.LOAD_LEVEL, redirectionLevelID);
        //SceneManager.LoadScene("Level" + (int)portalNumber);
    }
}
