using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rigidBody;
    [SerializeField] private float launchForce;
    [SerializeField] private string nameOfKillbox;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(Dying());
        }
    }

    private IEnumerator Dying()
    {
        rigidBody.velocity = new Vector2(0, launchForce);
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find(nameOfKillbox).GetComponent<BoxCollider2D>().enabled = false ;
        GetComponentInParent<WaypointFollower>().enabled = false;
        animator.SetTrigger("death");
        yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
    }
}
