using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour {
    public Transform playerCam;
    public Transform orientation;

    public CameraAim cameraAim;
    public Animator animator;
    public Gun gun;

    //Rotation and look
    public bool lockLook;
    private float xRotation;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;

    private bool canMoveAim;

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            cameraAim.SwitchToAimView();
        }
        if(Input.GetMouseButton(1)) {
            canMoveAim = true;
            animator.SetBool("Shoot", true);
        }
        if(Input.GetMouseButtonUp(1)) {
            canMoveAim = false;
            cameraAim.SwitchToDefault();
            animator.SetBool("Shoot", false);
        }

        if(canMoveAim)
            AimGun();
    }

    private void AimGun() {
        Look();
    }
    private float desiredX;
    private void Look() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        //Find current look rotation
        Vector3 rot = playerCam.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        //Rotate, and also make sure we dont over- or under-rotate.
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Perform the rotations
        playerCam.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
        orientation.transform.localRotation = Quaternion.Euler(0, desiredX, 0);
    }

    private void OnAnimatorIK() {
        //weapon aim at target
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.RightHand, gun.aimTarget);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, gun.aimTarget); ;
    }
}
