using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public PlayerController playerController;
    public WeaponController weaponController;
    public LevelController levelController;
    public TextMeshProUGUI XpEnemiesTxt;
    public GameObject AmmoniaThing;
    public GameObject AnnahilathoriThing;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        weaponController = GameObject.Find("Player").GetComponent<WeaponController>();
        levelController = GameObject.Find("UICanvas").GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("XpEnemies") != null)
        {
            if (GameObject.Find("XpEnemies").activeInHierarchy == true)
            {
                XpEnemiesTxt.text = $"{levelController.NoOfEnemiesForLevel} expected for this level. ({levelController.NoOfEnemiesForLevel * 2} Bullets required)";
            }
        }        
    }
    public void OnShopCloseCLick()
    {
        Debug.Log("Close Shop");
        levelController.LevelTime = 30f;
        levelController.CanvasOpen = false;        
    }
    public void OnOpenShopClick()
    {
        Debug.Log("Open Shop");
        levelController.NoOfEnemiesForLevel = levelController.NoOfEnemiesForLevel + 3;        
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
            AmmoniaThing.SetActive(true);
        }
        if (clickedBtn.transform.parent.name == "Ammo" && playerController.Coins >= 15)
        {
            playerController.Coins -= 15;
            weaponController.Ammo += 3;
            weaponController.AmmoTxt.text = $"You have {weaponController.Ammo} bullets left";
        }
        if (clickedBtn.transform.parent.name == "Annahilathori" && playerController.Coins >= 100)
        {
            playerController.Coins -= 100;
            weaponController.CanUseAnnahilathori = true;
            AmmoniaThing.SetActive(true);
        }
        if (clickedBtn.transform.parent.name == "Shotgun" && playerController.Coins >= 70)
        {
            playerController.Coins -= 70;
            weaponController.CanUseShotgun = true;
            Destroy(clickedBtn);
        }
        if (clickedBtn.transform.parent.name == "SMG" && playerController.Coins >= 120)
        {
            playerController.Coins -= 50;
            weaponController.CanUseSMG = true;
            Destroy(clickedBtn);
        }
    }
}
