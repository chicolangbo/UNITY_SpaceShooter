using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public Projectile projectilePrefab;
    public float projectileForce = 10f;

    private int currentBullet;
    private int maxBullet = 100;
    public int launchItem = 0;
    private Quaternion leftAngle = Quaternion.Euler(0f, 0f, 10f);
    private Quaternion rightAngle = Quaternion.Euler(0f, 0f, -10f);
    private Quaternion centerAngle = Quaternion.Euler(0f, 0f, 0f);

    public GameObject leftPoint;
    public GameObject rightPoint;
    public GameObject centerPoint;
    private ParticleSystem leftEffect;
    private ParticleSystem rightEffect;
    private ParticleSystem centerEffect;
    public GameObject explosionObj;
    private ParticleSystem explosionEffect;

    private void Awake()
    {
        currentBullet = maxBullet;
        leftEffect = leftPoint.GetComponent<ParticleSystem>();
        rightEffect = rightPoint.GetComponent<ParticleSystem>();
        centerEffect = centerPoint.GetComponent<ParticleSystem>();
        explosionEffect = explosionObj.GetComponent <ParticleSystem>();
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
        //var y = projectilePrefab.transform.up; // 
        //var x = projectilePrefab.transform.rotation.
    }

    public void TakeDamage()
    {
        // 사운드 추가
        explosionEffect.Stop();
        explosionEffect.Play();
        Destroy(gameObject);
        GameManager.Instance.OnPlayerDie();
    }

    private void Shoot(int item, Transform point, Quaternion angle)
    {
        var pos = point.position;
        var prj = Instantiate(projectilePrefab, pos, angle);
        prj.Launch(prj.transform.up, projectileForce);

        if(item%2 == 0)
        {
            centerEffect.Stop();
            centerEffect.Play();
        }
        if(item>0)
        {
            leftEffect.Stop();
            leftEffect.Play();
            rightEffect.Stop();
            rightEffect.Play();
        }
    }

    private IEnumerator ShootProjectiles()
    {
        while (currentBullet > 0)
        {
            currentBullet--;
            switch (launchItem)
            {
                case 0:
                    Shoot(0,centerPoint.transform, centerAngle);
                    break;
                case 1:
                    Shoot(1,leftPoint.transform, centerAngle);
                    Shoot(1,rightPoint.transform, centerAngle);
                    break;
                case 2:
                    Shoot(2,centerPoint.transform, centerAngle);
                    Shoot(2,leftPoint.transform, leftAngle);
                    Shoot(2,rightPoint.transform, rightAngle);
                    break;
                case 3:
                    Shoot(3,leftPoint.transform, leftAngle);
                    Shoot(3,rightPoint.transform, leftAngle);
                    Shoot(3,leftPoint.transform, rightAngle);
                    Shoot(3,rightPoint.transform, rightAngle);
                    break;
                case 4:
                    Shoot(4,centerPoint.transform, centerAngle);
                    Shoot(4,leftPoint.transform, leftAngle);
                    Shoot(4,rightPoint.transform, rightAngle);
                    Shoot(4,leftPoint.transform, leftAngle * leftAngle);
                    Shoot(4,rightPoint.transform, rightAngle * rightAngle);
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
