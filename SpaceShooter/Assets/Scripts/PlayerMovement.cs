using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private bool IsDragging = false;

    private new Rigidbody2D rigidbody2D;
    private float dragSpeed = 10f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
    private void FixedUpdate()
    {
        if (IsDragging)
        {
            var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = rigidbody2D.transform.position.z;
            rigidbody2D.transform.position = Vector3.Lerp(rigidbody2D.transform.position, newPos, dragSpeed * Time.deltaTime);
            //rigidbody2D.transform.position = new Vector3(newPos.x, newPos.y, rigidbody2D.transform.position.z);
        }
    }

    private void Update()
    {
        MouseUpDown();
    }
}
