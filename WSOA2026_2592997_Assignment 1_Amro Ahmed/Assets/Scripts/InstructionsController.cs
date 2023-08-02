using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    public GameObject CloseBtn;
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public GameObject Canvas4;
    public GameObject Canvas5;
    public GameObject Canvas6;
    public GameObject Canvas7;
    public GameObject Canvas8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnButtonClick(GameObject Button)
    {
        if (Button.transform.parent.name == "Items(1)")
        {
            Canvas1.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(2)")
        {
            Canvas2.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(3)")
        {
            Canvas3.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(4)")
        {
            Canvas4.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(5)")
        {
            Canvas5.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(6)")
        {
            Canvas6.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(7)")
        {
            Canvas7.SetActive(true);
        }
        if (Button.transform.parent.name == "Items(8)")
        {
            Canvas8.SetActive(true);
        }
        CloseBtn.SetActive(true);
    }
}
