using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public WeaponController weaponController;
    public int Health;
    public GameObject[] Hearts;
    public int Coins;
    public TextMeshProUGUI CoinsTxt;
    public bool Switched = false;
    public int CCTime = 0;
    public float timer = 0f;
    public TextMeshProUGUI CCtext;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        Health = 5;
        weaponController = GameObject.Find("Player").GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");
        Vector2 MoveDirection = new Vector2(HorizontalMove, VerticalMove);
        transform.Translate(MoveDirection * speed * Time.deltaTime, Space.World);
        if (Health == 0)
        {
            Die();
        }
        CoinsTxt.text = $"{Coins}$";
        GameObject[] ActiveEnemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach (GameObject f in ActiveEnemies)
        {
            if (CCTime > 0)
            {
                if (timer < 1)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    CCTime--;
                    CCtext.text = $"{CCTime}";
                    timer = 0;
                }
            }
            else
            {
                CCtext.text = "Ready";
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ammo(Clone)")
        {
            weaponController.Ammo += 2;
            Coins += 10;
            Destroy(collision.gameObject);
            weaponController.AmmoTxt.text = $"You have {weaponController.Ammo} bullets left";
        }
    }
    public void Die()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
