using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Crosshair;
    public int CrosshairRange;
    public int Weapon;
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
            CrosshairRange = 6;
        }
        Crosshair.transform.localPosition = MouseWorldPosition * CrosshairRange;
    }
}
