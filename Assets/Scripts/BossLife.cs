using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    [SerializeField] private float launchForce;
    [SerializeField] private string nameOfKillbox;
    [SerializeField] private float bossLives;
    [SerializeField] private AudioSource killSE;
    [SerializeField] private AudioSource finishSE;


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
            rigidBody.velocity = new Vector2(0, launchForce);
            killSE.Play();
            if(bossLives == 0)
            {
            StartCoroutine(Dying());
            }
            else
            {
            bossLives--;
            animator.SetTrigger("hit");
            }

        }
    }

    private IEnumerator Dying()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find(nameOfKillbox).GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInParent<WaypointFollower>().enabled = false;
        animator.SetTrigger("death");
        yield return new WaitForSeconds(1f);
        finishSE.Play();
        Destroy(transform.parent.gameObject);
        GameObject.Find("Enemy Generator").GetComponent<EnemyGenerator>().enabled = false;
        Destroy(GameObject.Find("Enemy Generator"));
        Destroy(GameObject.Find("LevelBlock"));
    }
}
