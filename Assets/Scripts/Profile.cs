using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Profile : MonoBehaviour
{
    public Text user;
    public Text L_ME;
    public Text L_TS;
    public Text L_EX;
    public Text L_WR;
    public Text L_SL;
    public Text L_TP;
    public int swis;

    public GameObject high_Panel;
    public GameObject ME_Panel;
    public GameObject SL_Panel;
    public GameObject TS_Panel;
    public GameObject EX_Panel;
    public GameObject WR_Panel;

    public Text min_score_B_ME;
    public Text min_score_I_ME;
    public Text min_score_P_ME;

    public Text min_score_B_TS;
    public Text min_score_I_TS;
    public Text min_score_P_TS;

    public Text min_score_B_EX;
    public Text min_score_I_EX;
    public Text min_score_P_EX;

    public Text min_score_B_WR;
    public Text min_score_I_WR;
    public Text min_score_P_WR;

    public Text min_score_B_SL;
    public Text min_score_I_SL;
    public Text min_score_P_SL;



    

    public Animator transPro;

    private float timeBetweenQ = 2f;
    public string user_data;
    // Start is called before the first frame update
    void Start()
    {
        swis = 0;
        PlayerData data = SaveSystem.LoadPlayer1();
        try{
             user_data = data.user_n;
        }catch (NullReferenceException ex){
            Debug.Log("No Loaded data");
        }
        user.text = data.user_n;
        L_ME.text = data.ME;
        L_TS.text = data.TS;
        L_EX.text = data.EX;
        L_WR.text = data.WR;
        L_SL.text = data.SL;
        L_TP.text = data.timerpressure;

        min_score_B_ME.text = data.mB_ME;
        min_score_I_ME.text = data.mI_ME;
        min_score_P_ME.text = data.mP_ME;

        min_score_B_TS.text = data.mB_TS;
        min_score_I_TS.text = data.mI_TS;
        min_score_P_TS.text = data.mP_TS;

        min_score_B_SL.text = data.mB_SL;
        min_score_I_SL.text = data.mI_SL;
        min_score_P_SL.text = data.mP_SL;

        min_score_B_EX.text = data.mB_EX;
        min_score_I_EX.text = data.mI_EX;
        min_score_P_EX.text = data.mP_EX;

        min_score_B_WR.text = data.mB_WR;
        min_score_I_WR.text = data.mI_WR;
        min_score_P_WR.text = data.mP_WR;

       
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

    public void High_pan(){
        high_Panel.SetActive(true);
        ME_Panel.SetActive(false);
        TS_Panel.SetActive(false);
        SL_Panel.SetActive(false);
        EX_Panel.SetActive(false);
        WR_Panel.SetActive(false);

    }

    public void ME_pan(){
        high_Panel.SetActive(false);
        ME_Panel.SetActive(true);
        TS_Panel.SetActive(false);
        SL_Panel.SetActive(false);
        EX_Panel.SetActive(false);
        WR_Panel.SetActive(false);
    }

    public void TS_pan(){
        high_Panel.SetActive(false);
        ME_Panel.SetActive(false);
        TS_Panel.SetActive(true);
        SL_Panel.SetActive(false);
        EX_Panel.SetActive(false);
        WR_Panel.SetActive(false);
    }

    public void SL_pan(){
        high_Panel.SetActive(false);
        ME_Panel.SetActive(false);
        TS_Panel.SetActive(false);
        SL_Panel.SetActive(true);
        EX_Panel.SetActive(false);
        WR_Panel.SetActive(false);
    }

    public void EX_pan(){
        high_Panel.SetActive(false);
        ME_Panel.SetActive(false);
        TS_Panel.SetActive(false);
        SL_Panel.SetActive(false);
        EX_Panel.SetActive(true);
        WR_Panel.SetActive(false);
    }

    public void WR_pan(){
        high_Panel.SetActive(false);
        ME_Panel.SetActive(false);
        TS_Panel.SetActive(false);
        SL_Panel.SetActive(false);
        EX_Panel.SetActive(false);
        WR_Panel.SetActive(true);
    }

    IEnumerator waitForNext1()
    {
        transPro.SetTrigger("Start");
        
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Yo!Delay");
        if(swis == 1){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    public void Back()
    {
        swis = 1;
        StartCoroutine(waitForNext1());
    }


}
