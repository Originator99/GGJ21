using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public Transform LookAt;
    public float movementSpeed = 1f;
    public Enemy enemyScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LookAt != null)
        {
            transform.LookAt(LookAt);
            if(Vector3.Distance(LookAt.position, transform.position) > 2f && !enemyScript.isDead)
                transform.position = Vector3.MoveTowards(transform.position, LookAt.position, movementSpeed);
        }
    }
}
