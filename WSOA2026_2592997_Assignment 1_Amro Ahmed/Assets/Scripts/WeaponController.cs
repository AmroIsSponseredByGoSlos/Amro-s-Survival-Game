using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Crosshair;
    public int CrosshairRange;
    public int Weapon;
    public GameObject Bullet;
    public GameObject PistolSpawn;
    private Vector2 SpawnPos;
    private Vector2 FireDirection;
    // Start is called before the first frame update
    void Start()
    {
        Weapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 MouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        transform.up = MouseWorldPosition;
        MouseWorldPosition.Normalize();
        if (Weapon == 1)
        {
            CrosshairRange = 2;
        }
        Crosshair.transform.position = MouseWorldPosition * CrosshairRange;
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
        if (Weapon == 1)
        {
            SpawnPos = new Vector2(PistolSpawn.transform.position.x, PistolSpawn.transform.position.y);
            FireDirection = new Vector2(PistolSpawn.transform.up.x, PistolSpawn.transform.up.y);
            FireDirection.Normalize();
        }
        GameObject newBullet = Instantiate(Bullet, SpawnPos, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.velocity = new Vector3(FireDirection.x, FireDirection.y, 0f) * 7;
        }
    }
}
