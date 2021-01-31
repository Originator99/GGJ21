using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerPoint : MonoBehaviour {
    public Action<GameObject> TriggerEnter;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
            TriggerEnter.Invoke(other.gameObject);
    }
}
