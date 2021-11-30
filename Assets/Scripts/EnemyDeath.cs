using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(Dying());
        }
    }

    private IEnumerator Dying()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetTrigger("death");
        GetComponent<WaypointFollower>().enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
