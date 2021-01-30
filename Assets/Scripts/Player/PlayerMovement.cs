using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Animator animator;
    public Transform cam;

    private CharacterController characterController;
    [SerializeField]
    private float moveSpeed = 5f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private void Awake() {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Speed", movement.magnitude);

        if(movement.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
