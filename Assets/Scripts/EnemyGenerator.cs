using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private string nameOfObject;
    [SerializeField] private float seconds;
    private Transform generator;
    private int loop;
    

    // Update is called once per frame
    void Start()
    {
        generator = GetComponent<Transform>();
        StartCoroutine(GenerateEnemies());
    }

    IEnumerator GenerateEnemies()
    {
        loop = 1;
        while (loop == 1)
        {
        Instantiate(GameObject.Find(nameOfObject),generator.position,generator.rotation);
        yield return new WaitForSeconds(seconds);
        }
        
    }
}
