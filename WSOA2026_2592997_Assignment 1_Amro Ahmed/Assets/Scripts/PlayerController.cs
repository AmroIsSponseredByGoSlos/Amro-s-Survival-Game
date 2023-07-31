using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public WeaponController weaponController;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        weaponController = GameObject.Find("Player").GetComponent<WeaponController>();
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ammo(Clone)")
        {
            weaponController.Ammo += 2;
            Destroy(collision.gameObject);
            weaponController.AmmoTxt.text = $"You have {weaponController.Ammo} bullets left";
        }
    }
}
