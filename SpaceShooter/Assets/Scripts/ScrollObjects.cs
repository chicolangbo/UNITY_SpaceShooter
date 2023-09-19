using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameOver)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
