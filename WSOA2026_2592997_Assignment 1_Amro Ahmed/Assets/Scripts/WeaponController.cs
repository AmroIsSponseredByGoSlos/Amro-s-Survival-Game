using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    public int Weapon;
    public GameObject Bullet;
    public GameObject PistolSpawn;
    public GameObject ShotgunSpawn;
    public GameObject SmgSpawn;
    private Vector2 SpawnPos;
    private Vector2 FireDirection;
    public TextMeshProUGUI AmmoTxt;
    public int Ammo;
    public GameObject Pistol;
    public GameObject Shotgun;
    public GameObject SMG;
    public float AmmoniaTime;
    public bool AmmoniaActive = false;
    public GameObject ShopCanvas;
    public GameObject EndOfRoundCanvas;
    public bool CanUseAmmonia = false;
    public bool CanUseAnnahilathori = false;
    public bool CanUseShotgun = false;
    public bool CanUseSMG = false;
    public AudioSource BGsrc;
    public AudioSource Pistolsrc;
    public AudioSource Shotgunsrc;
    public AudioSource SMGsrc;
    public AudioClip PistolSound, ShotgunSound, SMGSound, BGAudio;
    public GameObject AmmoniaThing;
    public GameObject AnnahilathoriThing;

    // Start is called before the first frame update
    void Start()
    {
        Weapon = 1;
        Ammo = 8;
        BGsrc.clip = BGAudio;
        BGsrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 MouseWorldPosition = Camera.main.ScreenToWorldPoint(MousePos);
        Pistol.transform.up = MouseWorldPosition;
        Shotgun.transform.up = MouseWorldPosition;
        SMG.transform.up = MouseWorldPosition;
        MouseWorldPosition.Normalize();
        if (Input.GetMouseButtonDown(0) && ShopCanvas.activeInHierarchy == false && EndOfRoundCanvas.activeInHierarchy == false)
        {
            Fire();
        }
        if (Input.GetKeyDown("1"))
        {
            Pistol.SetActive(true);
            Shotgun.SetActive(false);
            SMG.SetActive(false);
            Weapon = 1;
        }
        if (Input.GetKeyDown("2") && CanUseShotgun)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(true);
            SMG.SetActive(false);
            Weapon = 2;
        }
        if (Input.GetKeyDown("3") && CanUseSMG)
        {
            Pistol.SetActive(false);
            Shotgun.SetActive(false);
            SMG.SetActive(true);
            Weapon = 3;
        }
        //Ammonia PowerUp
        if (Input.GetKeyDown("q") && CanUseAmmonia)
        {
            AmmoniaActive = true;
            AmmoniaThing.SetActive(false);
            CanUseAmmonia = false;
        }
        if (AmmoniaActive)
        {
            if (AmmoniaTime < 5)
            {
                AmmoniaTime += Time.deltaTime;
                Ammo = 1000;
                if (Ammo > 100)
                {
                    AmmoTxt.text = $"You have infinite bullets left";
                }
            }
            else
            {
                AmmoniaActive = false;
                Ammo = 8;
                AmmoTxt.text = $"You have {Ammo} bullets left";
                AmmoniaTime = 0;
            }
        }
        //Annahilathori powerup
        if (Input.GetKeyDown("x") && CanUseAnnahilathori)
        {
            CanUseAnnahilathori = false;
            AnnahilathoriThing.SetActive(false);
            GameObject[] ActiveEnemies = GameObject.FindGameObjectsWithTag("Enemies");
            if (ActiveEnemies != null)
            {
                foreach (GameObject f in ActiveEnemies)
                {
                    Destroy(f);
                }
            }            
        }
    }
    public void Fire()
    {
        if (Weapon == 1 && Ammo > 0)
        {
            Pistolsrc.clip = PistolSound;
            Pistolsrc.Play();
            SpawnPos = new Vector2(PistolSpawn.transform.position.x, PistolSpawn.transform.position.y);
            FireDirection = new Vector2(PistolSpawn.transform.up.x, PistolSpawn.transform.up.y);
            FireDirection.Normalize();
            Ammo--;
            AmmoTxt.text = $"You have {Ammo} bullets left";
            GameObject newBullet = Instantiate(Bullet, SpawnPos, Quaternion.identity);
            Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.velocity = new Vector3(FireDirection.x, FireDirection.y, 0f) * 7;
            }
            if (newBullet != null)
            {
                Destroy(newBullet, 0.7f);
            }
        }
        if (Weapon == 2 && Ammo > 4)
        {
            for (int i = 0; i < 5; i++)
            {
                Shotgunsrc.clip = ShotgunSound;
                Shotgunsrc.Play();
                SpawnPos = new Vector2(ShotgunSpawn.transform.position.x, ShotgunSpawn.transform.position.y);
                float randomX = Random.Range(0f, 0.8f);
                float randomY = Random.Range(0f, 0.8f);
                FireDirection = new Vector2(ShotgunSpawn.transform.up.x + randomX, ShotgunSpawn.transform.up.y + randomY);
                FireDirection.Normalize();
                FireDirection.Normalize();
                Ammo--;
                AmmoTxt.text = $"You have {Ammo} bullets left";
                GameObject newBullet = Instantiate(Bullet, SpawnPos, Quaternion.identity);
                Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = new Vector3(FireDirection.x, FireDirection.y, 0f) * Random.Range(5, 7);
                }
                if (newBullet != null)
                {
                    Destroy(newBullet, 1.4f);
                }
            }            
        }
        if (Weapon == 3 && Ammo > 2)
        {
            for (int i = 0; i < 3; i++)
            {
                SMGsrc.clip = SMGSound;
                SMGsrc.Play();
                SpawnPos = new Vector2(SmgSpawn.transform.position.x, SmgSpawn.transform.position.y);
                float randomX = Random.Range(0f, 0.2f);
                float randomY = Random.Range(0f, 0.2f);
                FireDirection = new Vector2(SmgSpawn.transform.up.x + randomX, SmgSpawn.transform.up.y + randomY);
                FireDirection.Normalize();
                FireDirection.Normalize();
                Ammo--;
                AmmoTxt.text = $"You have {Ammo} bullets left";
                GameObject newBullet = Instantiate(Bullet, SpawnPos, Quaternion.identity);
                Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = new Vector3(FireDirection.x, FireDirection.y, 0f) * Random.Range(5, 7);
                }
                if (newBullet != null)
                {
                    Destroy(newBullet, 1f);
                }
            }
        }
    }
}
