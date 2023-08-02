using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public GameObject Enemy;
    public float LevelTime;
    public TextMeshProUGUI TimeTxt;
    public float Interval = 0;
    public int SpawnLocation;
    public GameObject[] Spawns;
    public GameObject EndOfLevelCanvas;
    public bool CanvasOpen = false;
    public GameObject Player;
    public GameObject Timer;
    public GameObject Ammo;
    public bool AmmoSpawned;
    public bool EnemiesSpawned;
    public int NoOfEnemiesForLevel;
    // Start is called before the first frame update
    void Start()
    {
        LevelTime = 30f;
        NoOfEnemiesForLevel = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelTime % 7 == 0 && !AmmoSpawned && LevelTime != 0)
        {
            RandomAmmo();
        }
        if (LevelTime % 5 == 0)
        {
            AmmoSpawned = false;
            EnemiesSpawned = false;
        }
        if (Interval < 1)
        {
            Interval += Time.deltaTime;
        }
        else
        {
            if (LevelTime > 0)
            {
                LevelTime--;
                TimeTxt.text = $"{LevelTime} Seconds Left";
                Interval = 0;
            }            
        }
        if (LevelTime % 7 == 0 && !EnemiesSpawned && LevelTime != 0)
        {
            SpawnEnemy((int)(NoOfEnemiesForLevel / 4));
        }
        if (LevelTime == 0 && CanvasOpen == false)
        {
            EndOfLevelCanvas.SetActive(true);
            GameObject[] ActiveEnemies = GameObject.FindGameObjectsWithTag("Enemies");
            if (ActiveEnemies != null)
            {
                foreach (GameObject f in ActiveEnemies)
                {
                    Destroy(f);
                }
            }
            GameObject[] ActiveAmmo = GameObject.FindGameObjectsWithTag("Ammo");
            if (ActiveAmmo != null)
            {
                foreach (GameObject f in ActiveAmmo)
                {
                    Destroy(f);
                }
            }
            Timer.SetActive(false);
            CanvasOpen = true;
        }
    }
    public void SpawnEnemy(int AmountToSpawn)
    {
        for (int i = 0; i < AmountToSpawn; i++)
        {
            SpawnLocation = Random.Range(1, 8);
            Instantiate(Enemy, Spawns[SpawnLocation].transform.position, Quaternion.identity);
        }
        EnemiesSpawned = true;
    }
    public void RandomAmmo()
    {
        Vector2 RandomPos = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
        Instantiate(Ammo, RandomPos, Quaternion.identity);
        AmmoSpawned = true;
    }
}
