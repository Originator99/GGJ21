using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointForce : MonoBehaviour {
    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            AddForce(Input.mousePosition);
        }
    }

    private void AddForce(Vector3 mousePos) {
        var ray = Camera.main.ScreenPointToRay(mousePos);
        var hits = Physics.RaycastAll(ray);
        foreach(var hit in hits) {
            var enemy = hit.collider.GetComponent<BaseModel>();
            if(enemy != null) {
                enemy.AddForce();
                enemy.DoRagDoll(true);
            }
        }
    }
}
