using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    //private GameObject ClickedBtn;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
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
        if (clickedBtn.transform.parent.name == "Healacopter")
        {
            playerController.Health = 5;
            foreach (GameObject f in playerController.Hearts)
            {
                f.gameObject.SetActive(true);
            }
        }
    }
}
