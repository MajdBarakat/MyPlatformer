using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerDialogue;

public class CollectSword : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("touched");
        StartCoroutine(RemoveSword());
    }

    IEnumerator RemoveSword()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
        Destroy(GameObject.Find("Global Light 2D"));
        Debug.Log("got here");
        //StartCoroutine(PlayerDialogue.Dialogue("Missed you buddy.."));
    }
}
