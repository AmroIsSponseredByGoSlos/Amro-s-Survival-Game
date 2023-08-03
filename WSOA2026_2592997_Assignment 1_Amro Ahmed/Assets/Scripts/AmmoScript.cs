using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public WeaponController weaponController;
    public PlayerController playerController;
    public GameObject Ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Ammo = gameObject;
        weaponController = GameObject.Find("Player").GetComponent<WeaponController>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (collision.gameObject.name == "Player")
        {
            weaponController.Ammo += 1;
            playerController.Coins += 10;
            Destroy(Ammo);
            weaponController.AmmoTxt.text = $"You have {weaponController.Ammo} bullets left";
        }
    }
}
