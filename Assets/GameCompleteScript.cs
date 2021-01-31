using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("trigger win");
        }
    }
}
