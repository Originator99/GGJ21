using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public Animator animator;

    public GameObject healthBarUI;
    public Image healthBar;

    public bool isDead;

    private int health = 5;
    private int currentHealth;

    private void Start() {
        animator.SetBool("Hit", false);
        animator.SetBool("Death", false);
        healthBarUI.gameObject.SetActive(true);
        currentHealth = health;
    }
    public void TakeDamage(int dmg) {
        if(currentHealth > 0) {
            currentHealth -= dmg;
            SetHealthBar();
            if(currentHealth > 0) {
                DoHitEffect();
            } else {
                DoDeadEffect();
            }
        }
    }

    private void SetHealthBar() {
        if(currentHealth > 0) {
            healthBar.transform.localScale = new Vector3((float)currentHealth / (float)health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        } else {
            healthBarUI.gameObject.SetActive(false);
        }
    }

    private void DoDeadEffect() {
        animator.SetBool("Hit", false);
        animator.SetBool("Death", true);
        GameEventSystem.RaiseGameEvent(EVENT_TYPE.ENEMY_KILLED);
        isDead = true;
    }
    private void DoHitEffect() {
        animator.SetBool("Hit", true);
        Invoke("ChangeHitToFalse", 0.2f);
    }

    private void ChangeHitToFalse() {
        animator.SetBool("Hit", false);
    }
}
