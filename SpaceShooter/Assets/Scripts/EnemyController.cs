using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public Projectile projectilePrefab;
    public float projectileForce = 10f;
    private int currentHp;
    private int maxHp = 2;
    private bool IsShoot = false;
    private float shootTimer = 0f;

    public ParticleSystem hitParticle;
    public ParticleSystem explosionParticle;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);

        currentHp = maxHp;
        if(Random.value < 0.8)
        {
            IsShoot = true;
            shootTimer = Random.Range(1f, 3f);
        }
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if(IsShoot && shootTimer <= 0f)
        {
            Shoot();
            IsShoot = false;
            shootTimer = Random.Range(2f, 3f);
        }
    }

    public void Movement()
    {

    }

    private void Shoot()
    {
        var pos = transform.position;
        var prj = Instantiate(projectilePrefab, pos, Quaternion.identity);
        prj.Launch(Vector3.down, projectileForce);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= 1;
        if(currentHp > 0)
        {
            hitParticle.Stop();
            hitParticle.Play();
        }
        else if (currentHp <= 0)
        {
            GameManager.Instance.AddScore(1);
            explosionParticle.Stop();
            explosionParticle.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.tag = "Untagged";
        }
    }
}
