using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject target;
    public int Health = 2;
    public GameObject Enemy;
    public GameObject Ammo;
    public PlayerController playerController;
    public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        playerController = target.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, 1.4f * Time.deltaTime);
        if (Health == 0)
        {
            Die();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            Enemy = gameObject;
            Health--;
            Destroy(col.gameObject);
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (Timer < 1)
            {
                Timer += Time.deltaTime;
            }
            else
            {
                playerController.Health--;
                playerController.Hearts[playerController.Health].SetActive(false);
                Timer = 0;
            }            
        }
    }
    void Die()
    {
        Instantiate(Ammo, Enemy.transform.position, Quaternion.identity);
        Destroy(Enemy);
    }
}
