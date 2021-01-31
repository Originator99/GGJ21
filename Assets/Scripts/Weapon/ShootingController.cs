using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour {
    public Transform rayPoint;
    public Transform crosshair;

    public Animator animator;

    public GameObject muzzleFlash;
    public GameObject muzzleFlashPrefab;

    //stats
    private int magSize = 60;
    private int currentMag = 0;
    private float reloadTime = 3.3f;
    private float firerate = 0.05f;
    private float firerate_timer;
    private int damage = 1;

    private bool aiming;
    private bool reloading;

    private void Start() {
        firerate_timer = 0;
        reloading = false;
        aiming = false;
        currentMag = magSize;
    }

    private void Update() {
        if(Input.GetMouseButton(1)) {
            Debug.DrawRay(rayPoint.transform.position, rayPoint.transform.TransformDirection(Vector3.forward) * 100, Color.red);
            aiming = true;
        }
        if(Input.GetMouseButtonUp(1)) {
            animator.SetBool("Fire", false);
            aiming = false;
        }

        if(aiming) {
            if(Input.GetMouseButton(0)) {
                CheckShoot();
            }
            if(Input.GetMouseButtonUp(0)) {
                animator.SetBool("Fire", false);
            }
        }
    }

    private void CheckShoot() {
        if(!reloading && currentMag > 0 && firerate_timer <= 0) {
            animator.SetBool("Fire", true);
            Shoot();
        }
        if(firerate_timer > 0) {
            firerate_timer -= Time.deltaTime;
        }
    }

    private void Shoot() {
        //muzzleFlash.SetActive(true);
        if(Physics.Raycast(rayPoint.transform.position, rayPoint.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 1000f)) {
            if(hit.collider != null) {
                OnRayCast(hit.collider.gameObject);
            }
        }
        firerate_timer = firerate;
        currentMag--;
        if(currentMag <= 0) {
            reloading = true;
            animator.SetBool("Reload", true);
            Invoke("Reload", reloadTime);
        }
        GameObject muzzleVFX = Instantiate(muzzleFlashPrefab, muzzleFlash.transform.position, Quaternion.identity);
        var ps = muzzleVFX.GetComponent<ParticleSystem>();
        if(ps != null)
            Destroy(muzzleVFX, ps.main.duration);
        else {
            var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
            Destroy(muzzleVFX, psChild.main.duration);
        }
    }

    private void OnRayCast(GameObject obj) {
        if(obj != null) {
            Debug.Log(obj.tag);
            if(obj.tag.ToLower().Contains("enemy")) {
                Enemy enemy = obj.GetComponent<Enemy>();
                if(enemy != null) {
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    private void Reload() {
        firerate_timer = 0;
        reloading = false;
        currentMag = magSize;
        animator.SetBool("Reload", false);
    }
}
