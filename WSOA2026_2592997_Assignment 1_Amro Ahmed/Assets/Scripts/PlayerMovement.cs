using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");
        Vector2 MoveDirection = new Vector2(HorizontalMove, VerticalMove);
        transform.Translate(MoveDirection * speed * Time.deltaTime, Space.World);
        MoveDirection.Normalize();
        if (MoveDirection != Vector2.zero)
        {
            transform.up = MoveDirection;
        }
    }
}
