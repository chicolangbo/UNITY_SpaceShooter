using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float height;
    private Vector2 spawnPos;

    private void Awake()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        height = boxCollider.size.y;
        Destroy(boxCollider);
        spawnPos = new Vector2(0, height);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < -height)
        {
            RePosition();
        }
    }

    private void RePosition()
    {
        transform.position = spawnPos;
    }
}
