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
    public LayerMask layerMask;
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
        if (col.gameObject.name == "Player")
        {
            playerController.Health--;
            playerController.Hearts[playerController.Health].SetActive(false);
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
        for (int i = 0; i < 15; i++)
        {
            float AngleForRay = i * 22.5f;
            float AngleRadians = AngleForRay * Mathf.Deg2Rad;
            Vector2 TravelDirection = new Vector2(Mathf.Cos(AngleRadians), Mathf.Sin(AngleRadians));
            if (Physics.Raycast(Enemy.transform.position, TravelDirection, out RaycastHit hitinfo, 2f, layerMask))
            {
                Debug.Log("Enemy Hit");
                //Instantiate(Ammo, Enemy.transform.position, Quaternion.identity);
                //Destroy(Enemy);
            }
            else
            {
                Debug.Log("No Enemy Hit");
                //Instantiate(Ammo, Enemy.transform.position, Quaternion.identity);
                //Destroy(Enemy);
            }
            Debug.DrawRay(Enemy.transform.position, TravelDirection * 2f, Color.red);
        }       
    }
}
