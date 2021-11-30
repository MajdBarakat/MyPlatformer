using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAgro : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.name == "Player")
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        GetComponentInParent<WaypointFollower>().enabled = false;
        Debug.Log("agrod" + rigidbody.velocity.x);
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(3f);
        GetComponentInParent<WaypointFollower>().enabled = true;
    }
}
