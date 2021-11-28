using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float offsetX;
    private float offsetY;

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        if (player.GetComponent<SpriteRenderer>().flipX == true)
        {
            offsetX = -5f;
            offsetY = 1f;
        }
        else
        {
            offsetX = 5f;
            offsetY = 1f;
        }
        transform.position = new Vector3(player.position.x + offsetX, player.position.y + offsetY, transform.position.z);

    }
}
