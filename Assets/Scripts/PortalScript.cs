using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public PortalNumber portalNumber;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if(other.CompareTag("Player"))
        {
            Debug.Log("player entered portal " + portalNumber);
            Debug.Log("Level" + portalNumber);
            Debug.Log("Level" + (int)portalNumber);
            Debug.Log("Level" + ((int)portalNumber));
            LoadLevelScene();
        }
    }

    private void LoadLevelScene()
    {
        SceneManager.LoadScene("Level" + (int)portalNumber);
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