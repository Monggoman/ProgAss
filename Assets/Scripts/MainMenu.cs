using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject panel;
    public GameObject panelshad;
    public GameObject inputField;

    public Animator transition;

    public GameObject TakeNote1;
    public GameObject TakeNote2;
    public GameObject TakeNote3;
    public GameObject TakeNote4;
    public GameObject TakeNote5;
    public GameObject TakeNote6;
    public GameObject TakeNote7;
    public GameObject Alert;

    public Button startbtn;
    public Button probtn;
    public Button histbtn;
    public Button quitbtn;

    public GameObject Mmenu;

    public static string user_n;
    public string ME;
    public string TS;
    public string EX;
    public string WR;
    public string SL;
    public int count;
    public int swit;

    private float timeBetweenQ = 2f;

    public bool var;

    public void BtnInteract1(bool var1)
    {
        startbtn.interactable = var1;
        probtn.interactable = var1;
        histbtn.interactable = var1;
        quitbtn.interactable = var1;
    }
    
    public void PlayGame() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        var = false;
        PlayerData data = SaveSystem.LoadPlayer();
        try{
             user_n = data.user_n;
        }catch (NullReferenceException ex){
            //panel.SetActive(true);
            //panelshad.SetActive(true);
            Debug.Log("Noise");
        }
        if(user_n == null)
        {
            panel.SetActive(true);
            panelshad.SetActive(true);
            

        }else if(user_n == ""){
            panel.SetActive(true);
            panelshad.SetActive(true);
        }else{
            Takenote();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    IEnumerator waitForNext1()
    {
        
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Yo!Delay");
        if(swit == 3){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }else if(swit == 2){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }else if(swit == 4){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
        
    }

    public void Takenote(){
        Mmenu.SetActive(false);
        TakeNote1.SetActive(true);
        count = 1;
    }

    public void AlertYes(){
        swit = 4;
        Mmenu.SetActive(true);
        var = false;
        BtnInteract1(var);
        StartCoroutine(waitForNext1());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
    public void AlertNo(){
        Alert.SetActive(false);
        Mmenu.SetActive(true);
        var = true;
        user_n = "";
        BtnInteract1(var);
    }
    
    public void nextPanel(){
        Debug.Log(count);
        if(count == 1){
            TakeNote1.SetActive(false);
            TakeNote2.SetActive(true);
            count++;
            Debug.Log(count);
        }else if(count == 2){
            TakeNote2.SetActive(false);
            TakeNote3.SetActive(true);
            count++;
            Debug.Log(count);
        }else if(count == 3){
            TakeNote3.SetActive(false);
            TakeNote4.SetActive(true);
            //panel.SetActive(true);
            //panelshad.SetActive(true);
            count++;
            //Alert.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if(count == 4){
            TakeNote4.SetActive(false);
            TakeNote5.SetActive(true);
            count++;
        }else if(count == 5){
            TakeNote5.SetActive(false);
            TakeNote6.SetActive(true);
            count++;
        }else if(count == 6){
            TakeNote6.SetActive(false);
            TakeNote7.SetActive(true);
            count++;
        }else if(count == 7){
            TakeNote7.SetActive(false);
            Alert.SetActive(true);
        }
    }

    
    public void Start(){
        swit = 0;
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
    

    public void StartGame() {
        
        
        user_n =  inputField.GetComponent<Text>().text;
        if(user_n != "")
        {
            Debug.Log(user_n);
            
            panel.SetActive(false);
            panelshad.SetActive(false);
            Takenote();
        }else{
            Debug.Log(user_n);
            //swit = 1;
            panel.SetActive(false);
            panelshad.SetActive(false);
            var = true;
            BtnInteract1(var);
            //StartCoroutine(waitForNext1());
        }
    }
    public void History()
    {
        swit = 3;
        StartCoroutine(waitForNext1());
        
        
    }

    public void Profile()
    {
        swit = 2;
        StartCoroutine(waitForNext1());
        
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        ME = data.ME;
        TS = data.TS;
        EX = data.EX;
        WR = data.WR;
        SL = data.SL;
        
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
