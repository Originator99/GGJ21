using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModel : MonoBehaviour {
    public Transform rig;
    public Collider[] colliders;
    public Animator animator;
    public Collider mainCollider;
    public Rigidbody rb;
    public Transform explosionPos;

    private void Start() {
        colliders = rig.GetComponentsInChildren<Collider>();
        DoRagDoll(false);
    }

    public void DoRagDoll(bool isRagdoll) {
        foreach(var collider in colliders) {
            collider.enabled = isRagdoll;
        }
        animator.enabled = !isRagdoll;
        mainCollider.enabled = !isRagdoll;
        rb.useGravity = !isRagdoll;
    }

    public void AddForce() {
        rb.AddExplosionForce(100, explosionPos.position, 5f, 3f);
    }
}
