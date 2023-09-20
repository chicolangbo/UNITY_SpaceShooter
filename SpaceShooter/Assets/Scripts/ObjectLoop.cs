using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLoop : MonoBehaviour
{
    public Vector2 initialPos;
    public GameObject obj;
    public List<GameObject> objects;
    public bool IsPlanet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Respawn"))
        {
            if(IsPlanet)
            {
                var index = UnityEngine.Random.Range(0, 2);
                var x = UnityEngine.Random.Range(-3f, 3f);
                initialPos = new Vector2(x, initialPos.y);
                Instantiate(objects[index], initialPos, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                var x = UnityEngine.Random.Range(-5f, 5f);
                initialPos = new Vector2(x, initialPos.y);
                Instantiate(obj, initialPos, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
