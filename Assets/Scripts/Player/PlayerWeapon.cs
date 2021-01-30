using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    public CameraAim cameraAim;
    public Animator animator;
    public Gun gun;

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            cameraAim.SwitchToAimView();
        }
        if(Input.GetMouseButton(1)) {
            animator.SetBool("Shoot", true);
        }
        if(Input.GetMouseButtonUp(1)) {
            cameraAim.SwitchToDefault();
            animator.SetBool("Shoot", false);
        }
    }
}
