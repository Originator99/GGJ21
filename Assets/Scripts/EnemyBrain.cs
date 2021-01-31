using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyBrain :MonoBehaviour {
    public Animator animator;
    public Transform attackRayPoint;
    public Transform LookAt;
    public float movementSpeed = 1f;

    private Enemy enemyScript;

    private void Awake() {
        enemyScript = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        if(LookAt != null) {
            transform.LookAt(LookAt);
            if(Vector3.Distance(LookAt.position, transform.position) > 2f && !enemyScript.isDead) {
                animator.SetBool("Walk", true);
                transform.position = Vector3.MoveTowards(transform.position, LookAt.position, movementSpeed * Time.deltaTime);
            } else {
                animator.SetBool("Walk", false);
            }

            Debug.DrawRay(attackRayPoint.position, attackRayPoint.TransformDirection(Vector3.forward) * 5f, Color.red);

            if(Physics.Raycast(attackRayPoint.position, attackRayPoint.TransformDirection(Vector3.forward), out RaycastHit hit, 5f)) {
                if(hit.collider != null && hit.collider.CompareTag("Player")) {
                    animator.SetBool("Attack", true);
                }
            } else {
                animator.SetBool("Attack", false);
            }
        }
    }
}
