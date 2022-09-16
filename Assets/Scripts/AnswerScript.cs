using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    int num1;
    QuizManager a;
    public Color startColor;


    
    
    
    /*public List<int> ME = new List<int>();
    public List<int> TS = new List<int>();
    public List<int> EX = new List<int>();
    public List<int> WR = new List<int>();
    public List<int> SL = new List<int>();*/
    
    //QuizManager name = new QuizManager();
    public Text ScoreText;
    /*
    public int count_1 = 0;
    public int count_2 = 0;
    public int count_3 = 0;*/
    private void Start()
    {
        startColor = GetComponent<Image>().color;
        
    }

    

    

    

    public void Answer()
    {
        if(isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            string text = gameObject.GetComponentInChildren<Text>().text;
            string text1 = gameObject.transform.GetChild(2).GetComponentInChildren<Text>().text;
            string infotext = gameObject.transform.GetChild(3).GetComponentInChildren<Text>().text;
            Debug.Log(infotext);
            quizManager.infoText.text = infotext;
            Debug.Log(text1);
            if(text1 == "ME")
            {
                Debug.Log(text);
                /*int.TryParse(text, out num1);
                ME.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_ME(text);
            }else if(text1 == "TS")
            {
                /*int.TryParse(text, out num1);
                TS.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_TS(text);
            }else if(text1 == "SL")
            {
                /*int.TryParse(text, out num1);
                SL.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_SL(text);
            }/**else if(text1 == "WR")
            {
                /*int.TryParse(text, out num1);
                WR.Add(num1);
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_WR(text);
            }**/else if(text1 == "EX")
            {
                /*int.TryParse(text, out num1);
                EX.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_EX(text);
            }
            //int.TryParse(text, out num1);
           // Debug.Log(num1);
            
            quizManager.correct();
            
            
        }
        else
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Wrong Answer");
            string text = gameObject.GetComponentInChildren<Text>().text;
            string text1 = gameObject.transform.GetChild(2).GetComponentInChildren<Text>().text;
            string infotext = gameObject.transform.GetChild(3).GetComponentInChildren<Text>().text;
            Debug.Log(infotext);
            quizManager.infoText.text = infotext;
            
            Debug.Log(text1);
            if(text1 == "ME")
            {
                Debug.Log(text);
                /*int.TryParse(text, out num1);
                ME.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_ME(text);
            }else if(text1 == "TS")
            {
                /*int.TryParse(text, out num1);
                TS.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_TS(text);
            }else if(text1 == "SL")
            {
                /*int.TryParse(text, out num1);
                SL.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_SL(text);
            }/**else if(text1 == "WR")
            {
                /*int.TryParse(text, out num1);
                WR.Add(num1);
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_WR(text);
            }**/else if(text1 == "EX")
            {
                /*int.TryParse(text, out num1);
                EX.Add(num1);*/
                a = GameObject.FindGameObjectWithTag("TagA").GetComponent<QuizManager>();
                a.add_tolist_EX(text);
            }
            
           // Debug.Log(num1);
            quizManager.wrong();
           // Debug.Log(gameObject.name);
            
            
        }
        
        
    }
    
    

}
