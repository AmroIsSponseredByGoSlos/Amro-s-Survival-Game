using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Item1Click()
    {
        Canvas1.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item2Click()
    {
        Canvas2.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item3Click()
    {
        Canvas3.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item4Click()
    {
        Canvas4.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item5Click()
    {
        Canvas5.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item6Click()
    {
        Canvas6.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item7Click()
    {
        Canvas7.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void Item8Click()
    {
        Canvas8.SetActive(true);
        CloseBtn.SetActive(true);
    }
    public void CloseBatn()
    {
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
        Canvas3.SetActive(false);
        Canvas4.SetActive(false);
        Canvas5.SetActive(false);
        Canvas6.SetActive(false);
        Canvas7.SetActive(false);
        Canvas8.SetActive(false);
        CloseBtn.SetActive(false);
    }
    public void Ready()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
