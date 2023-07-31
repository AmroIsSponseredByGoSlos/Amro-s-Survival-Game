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
    // Start is called before the first frame update
    void Start()
    {
        LevelTime = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interval < 1)
        {
            Interval += Time.deltaTime;
        }
        else
        {
            LevelTime--;
            TimeTxt.text = $"{LevelTime} Seconds Left";
            Interval = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            SpawnEnemy(2);
        }
    }
    public void SpawnEnemy(int AmountToSpawn)
    {
        for (int i = 0; i < AmountToSpawn; i++)
        {
            SpawnLocation = Random.Range(1, 8);
            Instantiate(Enemy, Spawns[SpawnLocation].transform.position, Quaternion.identity);
        }        
    }
}
