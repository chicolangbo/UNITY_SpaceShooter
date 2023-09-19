using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    enum Owner
    {
        Player,
        Enemy
    }

    private new Rigidbody2D rigidbody2D;
    private Owner who;
    public int damage = 1;
    public int owner;
    

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
        who = (Owner)owner;
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(who == Owner.Player)
        {
            if(collision.CompareTag("Enemy"))
            {
                collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.CompareTag("Player"))
            {
                collision.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
                Destroy(gameObject);
            }
        }
    }
}
