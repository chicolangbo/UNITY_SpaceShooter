using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : MonoBehaviour
{
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
        if(collision.CompareTag("Player"))
        {
            var x = UnityEngine.Random.Range(-5f, 5f);
            Vector2 initialPos = new Vector2(x, 20f);
            Instantiate(this, initialPos, Quaternion.identity);
            collision.GetComponent<PlayerController>().PowerUp(1);
            Destroy(gameObject);
        }
    }
}
