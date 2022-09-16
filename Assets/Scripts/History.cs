using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class History : MonoBehaviour
{
    MainMenu b;
    public Text L_ME;
    public Text L_TS;
    public Text L_EX;
    public Text L_WR;
    public Text L_SL;
    public Text L_TP;

    public Text N_ME;
    public Text N_TS;
    public Text N_EX;
    public Text N_WR;
    public Text N_SL;
    public Text N_TP;
    public int swi;
    public int num;

    public string Last_s;
    public string Latest_s;

    public GameObject Last_image;
    public GameObject Latest_image;

    public Animator transHis;

    private float timeBetweenQ = 2f;
    public string user_data;
    void Start()
    {
        swi = 0;
        num = 0;
        PlayerData data = SaveSystem.LoadPlayer();
        try{
             user_data = data.user_n;
        }catch (NullReferenceException ex){
            Debug.Log("No Loaded data");
        }
        do{
       Debug.Log("Load Last is running");
        L_ME.text = data.ME;
        L_TS.text = data.TS;
        L_EX.text = data.EX;
        L_WR.text = data.WR;
        L_SL.text = data.SL;
        L_TP.text = data.timerpressure;
        Last_s = data.time_s;
        num++;
        }while(num != 1);
        PlayerData data1 = SaveSystem.LoadPlayer1();
       Debug.Log("Load New is running");
        N_ME.text = data1.ME;
        N_TS.text = data1.TS;
        N_EX.text = data1.EX;
        N_WR.text = data1.WR;
        N_SL.text = data1.SL;
        N_TP.text = data1.timerpressure;
        Latest_s = data1.time_s;

        Last_image.GetComponent<TooltipTrigger>().header = Last_s;
        Latest_image.GetComponent<TooltipTrigger>().header = Latest_s;
        
    }
    IEnumerator waitForNext2()
    {
        transHis.SetTrigger("Start");
        
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Yo!Delay");
        if(swi == 1){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
    public void Back()
    {
       swi = 1;
       StartCoroutine(waitForNext2());
    }

    public GameObject Warning;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Warning.SetActive(true);
        }
    }

    public void btn_y()
    {
        Application.Quit();
    }

    public void btn_n(){
        Warning.SetActive(false);
    }
    /*public History(MainMenu menu)
    {
        L_ME.text = menu.ME;
        L_TS.text = menu.TS;
        L_EX.text = menu.EX;
        L_WR.text = menu.WR;
        L_SL.text = menu.SL;
        Debug.Log("This running");
    } */
}
