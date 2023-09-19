using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool IsDragging = false;

    private Rigidbody2D rigidbody2d;
    private float dragSpeed = 10f;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void MouseUpDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsDragging = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            IsDragging = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseUpDown();

        if (IsDragging)
        {
            var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rigidbody2d.transform.position = Vector3.Lerp(rigidbody2d.transform.position, newPos, dragSpeed * Time.deltaTime);
            //rigidbody2d.transform.position = new Vector3(newPos.x, newPos.y, rigidbody2d.transform.position.z);
        }
    }
}
