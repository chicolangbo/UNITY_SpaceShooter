using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<RotateEnemies> rotationMode;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameOver)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        // 5초마다 랜덤으로 스폰
        while(!GameManager.Instance.IsGameOver)
        {
            if(Random.Range(0, 2) == 0)
            {
                Instantiate(rotationMode[0]);
            }
            else
            {
                Instantiate(rotationMode[1]);
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
