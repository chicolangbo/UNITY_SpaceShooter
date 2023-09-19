using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float projectileForce = 10f;

    private int currentBullet;
    private int maxBullet = 100;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject centerPoint;
    private ParticleSystem leftEffect;
    private ParticleSystem rightEffect;
    private ParticleSystem centerEffect;

    private void Awake()
    {
        currentBullet = maxBullet;
        leftEffect = leftPoint.GetComponent<ParticleSystem>();
        rightEffect = rightPoint.GetComponent<ParticleSystem>();
        centerEffect = centerPoint.GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(ShootProjectiles());
    }

    private void FixedUpdate()
    {
    }

    private void Update()
    {
        
    }

    private IEnumerator ShootProjectiles()
    {
        while (currentBullet > 0)
        {
            currentBullet--;
            var pos = centerPoint.transform.position; // 일단 중앙만 발사
            var prj = Instantiate(projectilePrefab, pos, Quaternion.identity);
            prj.Launch(new Vector2(0f, 1f), projectileForce);
            centerEffect.Stop();
            centerEffect.Play();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
