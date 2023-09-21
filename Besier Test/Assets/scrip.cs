using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scrip : MonoBehaviour
{
    public CinemachineSmoothPath path;
    public float speed = 5f;
    private float distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = path.EvaluateLocalPosition(distanceTravelled);
    }
}
