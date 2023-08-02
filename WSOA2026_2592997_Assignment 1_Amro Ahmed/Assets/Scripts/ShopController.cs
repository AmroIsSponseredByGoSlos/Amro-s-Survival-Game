using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public PlayerController playerController;
    public WeaponController weaponController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        weaponController = GameObject.Find("Player").GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnShopCloseCLick()
    {
        Debug.Log("Close Shop");
    }
    public void OnOpenShopClick()
    {
        Debug.Log("Open Shop");
    }
    public void Buy(GameObject clickedBtn)
    {
        if (clickedBtn.transform.parent.name == "Healacopter" && playerController.Coins >= 30)
        {
            playerController.Health = 5;
            playerController.Coins -= 30;
            foreach (GameObject f in playerController.Hearts)
            {
                f.gameObject.SetActive(true);
            }
        }
        if (clickedBtn.transform.parent.name == "Ammonia" && playerController.Coins >= 50)
        {
            playerController.Coins -= 50;
            weaponController.CanUseAmmonia = true;
        }
        if (clickedBtn.transform.parent.name == "Annahilathori" && playerController.Coins >= 100)
        {
            playerController.Coins -= 100;
            weaponController.CanUseAmmonia = true;
        }
        if (clickedBtn.transform.parent.name == "Shotgun" && playerController.Coins >= 70)
        {
            playerController.Coins -= 70;
            weaponController.CanUseShotgun = true;
        }
        if (clickedBtn.transform.parent.name == "SMG" && playerController.Coins >= 120)
        {
            playerController.Coins -= 120;
            weaponController.CanUseSMG = true;
        }
    }
}
