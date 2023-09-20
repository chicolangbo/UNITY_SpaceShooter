using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemies : MonoBehaviour
{
    private float rotationSpeed = 70f;
    public bool clockDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (clockDirection)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmount);            
        }
        else
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, -rotationAmount);
        }
    }
}
