using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public PlayerData gamer;

    public GameObject Timers;

    public string call_user;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public GameObject Warning;

    public GameObject InfoPanel;

    //third phase
    public GameObject BasicPanel;
    public GameObject BasicPanel2;
    public GameObject BasicPanel3;
    public GameObject InterPanel;
    public GameObject InterPanel2;
    public GameObject InterPanel3;
    public GameObject ProPanel;
    public GameObject ProPanel2;
    public GameObject ProPanel3;

    public GameObject checkPanel;

    public Text infoText;

    public Animator trans;    

    public GameObject YesButton;
    public GameObject NoButton;

    private float timeBetweenQ = 7f;
    AnswerScript name = new AnswerScript();

    public Text QuestionText;
    public Text ScoreText;
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;
    public Text ScoreText5;
    public Text username;

    public List<int> ME = new List<int>();
    public List<int> TS = new List<int>();
    public List<int> EX = new List<int>();
    public List<int> WR = new List<int>();
    public List<int> SL = new List<int>();

    public string score_ME;
    public string score_TS;
    public string score_EX;
    public string score_WR;
    public string score_SL;

    public string tem_ME;
    public string tem_EX;
    public string tem_WR;
    public string tem_TS;
    public string tem_SL;
    public string tem_TP;
    public string tem_save;

    public int sc_ME;
    public int sc_EX;
    public int sc_WR;
    public int sc_TS;
    public int sc_SL;

    public Button option_1;
    public Button option_2;
    public Button option_3;
    public Button opt_pass;

    


    public bool var = true;

    int TotalQuestions = 0;
    public int score;

    public int mark;

    public string time_save;

    private void Start()
    {
        time_save = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm");
        Debug.Log(time_save);
        call_user = MainMenu.user_n;
        TotalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

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

    public void BtnInteract(bool var)
    {
        option_1.interactable = var;
        option_2.interactable = var;
        option_3.interactable = var;
        opt_pass.interactable = var;
            
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        
        //ScoreText.text = score + "/" + TotalQuestions;
        username.text = call_user;
        a_ME(ME);
        a_TS(TS);
        a_SL(SL);
        a_WR(WR);
        a_EX(EX);
    }

    public void correct()
    {
        InfoPanel.SetActive(true);
       // yield return new WaitForSeconds(2);
        StartCoroutine(waitForNext());
        score += 1;
        /*
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        */
    }

    public void wrong()
    {
        InfoPanel.SetActive(true);
        //yield return new WaitForSeconds(2);
        StartCoroutine(waitForNext());
        /*
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
        */
    }

    public GameObject btn_pass;
    public string s_check;
    public void pass()
    {
        s_check = btn_pass.transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].category;
        if(s_check == "ME")
        {
            Debug.Log("Basic");
            Timers.GetComponent<Timer>().timeValue -= 10;
            add_tolist_ME("1");
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }else if(s_check == "TS")
        {
            Debug.Log("Basic");
            Timers.GetComponent<Timer>().timeValue -= 10;
            add_tolist_TS("1");
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }else if(s_check == "SL")
        {
            Debug.Log("Basic");
            Timers.GetComponent<Timer>().timeValue -= 10;
            add_tolist_SL("1");
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }else if(s_check == "EX")
        {
            Debug.Log("Basic");
            Timers.GetComponent<Timer>().timeValue -= 10;
            add_tolist_EX("1");
            QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }
    }

    
    
    

    public IEnumerator waitForNext()
    {
        
        yield return new WaitForSeconds(timeBetweenQ);
        BtnInteract(var);
        QnA.RemoveAt(currentQuestion);
        InfoPanel.SetActive(false);
        generateQuestion();
    }

    public void Back()
    {
        WarningPanel();
    }

    public void Yesclick(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Noclick(){
        Warning.SetActive(false);
    }

    public void WarningPanel()
    {
        Warning.SetActive(true);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(1).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].values[i];
            options[i].transform.GetChild(2).GetComponent<Text>().text = QnA[currentQuestion].category;
            options[i].transform.GetChild(3).GetComponent<Text>().text = QnA[currentQuestion].info[i];
            options[i].GetComponent<TooltipTrigger>().content = QnA[currentQuestion].desc[i];
            
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            QuizPanel.SetActive(false);
            generateRandomQ();
            //GameOver();
        }
    }

    public float timeScored;
    public float maxtime = 360;
    public float totalperc;
    public string score_TP;
    
    public void TimeScore()
    {
        timeScored = Timers.GetComponent<Timer>().timeValue;
        totalperc = (timeScored / maxtime)*100; 

        if(totalperc <= 30)
        {
            
            
            ScoreText5.text = "Time Pressure: Basic: " + Mathf.RoundToInt(totalperc).ToString()+"%";
            score_TP = "Basic: "+Mathf.RoundToInt(totalperc);
            
            
        }else if(totalperc >= 30 & totalperc <= 60)
        {
            
            
            ScoreText5.text = "Time Pressure: Intermediate: " + Mathf.RoundToInt(totalperc).ToString()+"%";
            score_TP = "Intermediate: "+Mathf.RoundToInt(totalperc);
        }else if(totalperc >= 60 & totalperc <= 100)
        {
            
            
            ScoreText5.text = "Time Pressure: Proficient: " + Mathf.RoundToInt(totalperc).ToString()+"%";
            score_TP = "Proficient: "+Mathf.RoundToInt(totalperc);
        }
        
        
    }

    //THIRD PHASE
    public GameObject basic_c1_IF;//input field
    public GameObject basic_c2_IF;
    public GameObject basic_c3_IF;

    public GameObject basic2_c1_IF;//input field
    public GameObject basic2_c2_IF;
    public GameObject basic2_c3_IF;

    public GameObject basic3_c1_IF;//input field
    public GameObject basic3_c2_IF;
    public GameObject basic3_c3_IF;

    public GameObject inter_c1_IF;//input field
    public GameObject inter_c2_IF;
    public GameObject inter_c3_IF;

    public GameObject inter2_c1_IF;//input field
    public GameObject inter2_c2_IF;
    public GameObject inter2_c3_IF;

    public GameObject inter3_c1_IF;//input field
    public GameObject inter3_c2_IF;
    public GameObject inter3_c3_IF;

    public GameObject pro_c1_IF;//input field
    public GameObject pro_c2_IF;
    public GameObject pro_c3_IF;

    public GameObject pro2_c1_IF;//input field
    public GameObject pro2_c2_IF;
    public GameObject pro2_c3_IF;

    public GameObject pro3_c1_IF;//input field
    public GameObject pro3_c2_IF;
    public GameObject pro3_c3_IF;

    public Text chk_text;
    string ans1;
    string ans2;
    string ans3;

    public List<GameObject> Panels;
   // public List<GameObject> Buttons;

    public int currentProblem;

    public void generateRandomQ(){
        if (Panels.Count > 0)
        {
            currentProblem = UnityEngine.Random.Range(0, Panels.Count);

            Panels[currentProblem].SetActive(true); 
        }
        else
        {
            TimeScore();
            GameOver();
        }
    }

    

    public void nextpanel_basic2(){
        basic_checking();
        mark = 1;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_basic3(){
        basic2_checking();
        mark = 2;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_inter(){
        basic3_checking();
        mark = 3;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_inter2(){
        inter_checking();
        mark = 4;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_inter3(){
        inter2_checking();
        mark = 5;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_pro(){
        inter3_checking();
        mark = 6;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_pro2(){
        pro_checking();
        mark = 7;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void nextpanel_pro3(){
        pro2_checking();
        mark = 8;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public void res_panel(){
        pro3_checking();
        mark = 9;
        checkPanel.SetActive(true);
        StartCoroutine(wait_next());
    }

    public IEnumerator wait_next()
    {
        yield return new WaitForSeconds(1.0f);
        checkPanel.SetActive(false);
        Panels[currentProblem].SetActive(false);
        Panels.RemoveAt(currentProblem);
        generateRandomQ();

        /*if(mark == 1){
            checkPanel.SetActive(false);
            BasicPanel.SetActive(false);
            BasicPanel2.SetActive(true);
            
        }else if(mark == 2){
            checkPanel.SetActive(false);
            BasicPanel2.SetActive(false);
            BasicPanel3.SetActive(true);
           
        }else if(mark == 3){
            checkPanel.SetActive(false);
            BasicPanel3.SetActive(false);
            InterPanel.SetActive(true);
           
        }else if(mark == 4){
            checkPanel.SetActive(false);
            InterPanel.SetActive(false);
            InterPanel2.SetActive(true);
           
        }else if(mark == 5){
            checkPanel.SetActive(false);
            InterPanel2.SetActive(false);
            InterPanel3.SetActive(true);
            
        }else if(mark == 6){
            checkPanel.SetActive(false);
            InterPanel3.SetActive(false);
            ProPanel.SetActive(true);
           
        }else if(mark == 7){
            checkPanel.SetActive(false);
            ProPanel.SetActive(false);
            ProPanel2.SetActive(true);
           
        }else if(mark == 8){
            checkPanel.SetActive(false);
            ProPanel2.SetActive(false);
            ProPanel3.SetActive(true);
            
        }else if(mark == 9){
            checkPanel.SetActive(false);
            ProPanel3.SetActive(false);
            GameOver();
        }*/

    }

    public void basic_checking()
    {
        ans1 = basic_c1_IF.GetComponent<Text>().text;
        ans2 = basic_c2_IF.GetComponent<Text>().text;
        ans3 = basic_c3_IF.GetComponent<Text>().text;

        if(ans1 == "for" && ans2 == "in" && ans3 == "var")
        {
            add_tolist_WR("1");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
            add_tolist_WR("1");
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void basic2_checking()
    {
        ans1 = basic2_c1_IF.GetComponent<Text>().text;
        ans2 = basic2_c2_IF.GetComponent<Text>().text;
        ans3 = basic2_c3_IF.GetComponent<Text>().text;

        if(ans1 == "len" && ans2 == "return" && ans3 == "return")
        {
            add_tolist_WR("1");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
            
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void basic3_checking()
    {
        ans1 = basic3_c1_IF.GetComponent<Text>().text;
        ans2 = basic3_c2_IF.GetComponent<Text>().text;
        ans3 = basic3_c3_IF.GetComponent<Text>().text;

        if(ans1 == "def" && ans2 == "x" && ans3 == "square")
        {
            add_tolist_WR("1");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
          
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void inter_checking()
    {
        ans1 = inter_c1_IF.GetComponent<Text>().text;
        ans2 = inter_c2_IF.GetComponent<Text>().text;
        ans3 = inter_c3_IF.GetComponent<Text>().text;

        if(ans1 == "for" && ans2 == "isinstance" && ans3 == "str")
        {
            add_tolist_WR("2");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
           
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void inter2_checking()
    {
        ans1 = inter2_c1_IF.GetComponent<Text>().text;
        ans2 = inter2_c2_IF.GetComponent<Text>().text;
        ans3 = inter2_c3_IF.GetComponent<Text>().text;

        if(ans1 == "join" && ans2 == "string" && ans3 == "lower")
        {
            add_tolist_WR("2");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
           
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void inter3_checking()
    {
        ans1 = inter3_c1_IF.GetComponent<Text>().text;
        ans2 = inter3_c2_IF.GetComponent<Text>().text;
        ans3 = inter3_c3_IF.GetComponent<Text>().text;

        if(ans1 == "return" && ans2 == "sorted" && ans3 == "reverse")
        {
            add_tolist_WR("2");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
            
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void pro_checking()
    {
        ans1 = pro_c1_IF.GetComponent<Text>().text;
        ans2 = pro_c2_IF.GetComponent<Text>().text;
        ans3 = pro_c3_IF.GetComponent<Text>().text;

        if(ans1 == "range" && ans2 == "x%2" && ans3 == "split")
        {
            add_tolist_WR("3");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
            
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void pro2_checking()
    {
        ans1 = pro2_c1_IF.GetComponent<Text>().text;
        ans2 = pro2_c2_IF.GetComponent<Text>().text;
        ans3 = pro2_c3_IF.GetComponent<Text>().text;

        if(ans1 == "arr" && ans2 == "True" && ans3 == "pop")
        {
            add_tolist_WR("3");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
           
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    public void pro3_checking()
    {
        ans1 = pro3_c1_IF.GetComponent<Text>().text;
        ans2 = pro3_c2_IF.GetComponent<Text>().text;
        ans3 = pro3_c3_IF.GetComponent<Text>().text;

        if(ans1 == "char" && ans2 == "count" && ans3 == "nstring")
        {
            add_tolist_WR("3");
            chk_text.text = "Correct";
            checkPanel.GetComponent<Image>().color = Color.green;
        }else{
            
            chk_text.text = "Wrong";
            checkPanel.GetComponent<Image>().color = Color.red;
        }
    }

    int num1;
    int count_1;
    int count_2;
    int count_3;
    public void add_tolist_ME(string x)
    {
        int.TryParse(x, out num1);
        ME.Add(num1);
    }
    public void add_tolist_TS(string x)
    {
        int.TryParse(x, out num1);
        TS.Add(num1);
    }
    public void add_tolist_SL(string x)
    {
        int.TryParse(x, out num1);
        SL.Add(num1);
    }
    
    public void add_tolist_WR(string x)
    {
        int.TryParse(x, out num1);
        WR.Add(num1);
    }
    public void add_tolist_EX(string x)
    {
        int.TryParse(x, out num1);
        EX.Add(num1);
    }

    public string minorB_ME;
    public string minorI_ME;
    public string minorP_ME;

    public string minorB_SL;
    public string minorI_SL;
    public string minorP_SL;

    public string minorB_TS;
    public string minorI_TS;
    public string minorP_TS;

    public string minorB_EX;
    public string minorI_EX;
    public string minorP_EX;

    public string minorB_WR;
    public string minorI_WR;
    public string minorP_WR;

    public void a_ME(List<int> l_ME)
    {
        count_1 = 0;
        count_2 = 0;
        count_3 = 0;
        foreach (int x in l_ME)
        {
            if(x==1)
            {
                count_1 = count_1 + 33;
            }else if(x==2)
            {
                count_2 = count_2 + 33;
            }else if(x==3)
            {
                count_3 = count_3 + 33;
            }
        }

        if(count_1 > count_2 & count_1 > count_3)
        {
            ScoreText.text = "Mastery in Environment: Basic - " + count_1+"%";
            score_ME = "Basic: "+count_1+"";
            sc_ME = count_1;
            minorB_ME = "Basic: "+count_1+"";
            minorI_ME = "Intermediate: "+count_2+"";
            minorP_ME = "Proficient: "+count_3+"";
            
        }else if(count_2 > count_1 & count_2 > count_3){
            ScoreText.text = "Mastery in Environment: Intermediate - " + count_2+"%";
            score_ME = "Intermediate: "+count_2+"";
            sc_ME = count_2;
            minorB_ME = "Basic: "+count_1+"";
            minorI_ME = "Intermediate: "+count_2+"";
            minorP_ME = "Proficient: "+count_3+"";
        }else if(count_3 > count_1 & count_3 > count_2)
        {
            ScoreText.text = "Mastery in Environment: Proficient - " + count_3+"%";
            score_ME = "Proficient: "+count_3+"";
            sc_ME = count_3;
            minorB_ME = "Basic: "+count_1+"";
            minorI_ME = "Intermediate: "+count_2+"";
            minorP_ME = "Proficient: "+count_3+"";
        }else{
            ScoreText.text = "Mastery in Environment: Basic: 33%";
            score_ME = "Basic: 33";
            sc_ME = count_1;
            minorB_ME = "Basic: "+count_1+"";
            minorI_ME = "Intermediate: "+count_2+"";
            minorP_ME = "Proficient: "+count_3+"";
        }
        
    }

    public void a_TS(List<int> l_TS)
    {
        count_1 = 0;
        count_2 = 0;
        count_3 = 0;
        foreach (int x in l_TS)
        {
            if(x==1)
            {
                count_1 = count_1 + 33;
            }else if(x==2)
            {
                count_2 = count_2 + 33;
            }else if(x==3)
            {
                count_3 = count_3 + 33;
            }
        }
        Debug.Log(count_1);
        Debug.Log(count_2);
        Debug.Log(count_3);

        if(count_1 > count_2 & count_1 > count_3)
        {
            ScoreText1.text = "Troubleshooting: Basic - " + count_1+"%";
            score_TS = "Basic: "+count_1+"";
            sc_TS = count_1;
            minorB_TS = "Basic: "+count_1+"";
            minorI_TS = "Intermediate: "+count_2+"";
            minorP_TS = "Proficient: "+count_3+"";
        }else if(count_2 > count_1 & count_2 > count_3){
            ScoreText1.text = "Troubleshooting: Intermediate - " + count_2+"%";
            score_TS = "Intermediate: "+count_2+"";
            sc_TS = count_2;
            minorB_TS = "Basic: "+count_1+"";
            minorI_TS = "Intermediate: "+count_2+"";
            minorP_TS = "Proficient: "+count_3+"";
        }else if(count_3 > count_1 & count_3 > count_2)
        {
            ScoreText1.text = "Troubleshooting: Proficient - " + count_3+"%";
            score_TS = "Proficient: "+count_3+"";
            sc_TS = count_3;
            minorB_TS = "Basic: "+count_1+"";
            minorI_TS = "Intermediate: "+count_2+"";
            minorP_TS = "Proficient: "+count_3+"";
        }else{
            ScoreText1.text = "Troubleshooting: Basic: 33%";
            score_TS = "Basic: 33";
            sc_TS = count_1;
            minorB_TS = "Basic: "+count_1+"";
            minorI_TS = "Intermediate: "+count_2+"";
            minorP_TS = "Proficient: "+count_3+"";
        }
        
    }

    public void a_SL(List<int> l_SL)
    {
        count_1 = 0;
        count_2 = 0;
        count_3 = 0;
        foreach (int x in l_SL)
        {
            if(x==1)
            {
                count_1 = count_1 + 33;
            }else if(x==2)
            {
                count_2 = count_2 + 33;
            }else if(x==3)
            {
                count_3 = count_3 + 33;
            }
        }
        

        if(count_1 > count_2 & count_1 > count_3)
        {
            ScoreText2.text = "Self-Learning: Basic - " + count_1+"%";
            score_SL = "Basic: "+count_1+"";
            sc_SL = count_1;
            minorB_SL = "Basic: "+count_1+"";
            minorI_SL = "Intermediate: "+count_2+"";
            minorP_SL = "Proficient: "+count_3+"";
        }else if(count_2 > count_1 & count_2 > count_3){
            ScoreText2.text = "Self-Learning: Intermediate - " + count_2+"%";
            score_SL = "Intermediate: "+count_2+"";
            sc_SL = count_2;
            minorB_SL = "Basic: "+count_1+"";
            minorI_SL = "Intermediate: "+count_2+"";
            minorP_SL = "Proficient: "+count_3+"";
        }else if(count_3 > count_1 & count_3 > count_2)
        {
            ScoreText2.text = "Self-Learning: Proficient - " + count_3+"%";
            score_SL = "Proficient: "+count_3+"";
            sc_SL = count_3;
            minorB_SL = "Basic: "+count_1+"";
            minorI_SL = "Intermediate: "+count_2+"";
            minorP_SL = "Proficient: "+count_3+"";
        }else{
            ScoreText2.text = "Self-Learning: Basic: 33%";
            score_SL = "Basic: 33";
            sc_SL = count_1;
            minorB_SL = "Basic: "+count_1+"";
            minorI_SL = "Intermediate: "+count_2+"";
            minorP_SL = "Proficient: "+count_3+"";
        }
        
    }


    public void a_WR(List<int> l_WR)
    {
        count_1 = 0;
        count_2 = 0;
        count_3 = 0;
        foreach (int x in l_WR)
        {
            if(x==1)
            {
                count_1 = count_1 + 33;
            }else if(x==2)
            {
                count_2 = count_2 + 33;
            }else if(x==3)
            {
                count_3 = count_3 + 33;
            }
        }

        if(count_1 > count_2 & count_1 > count_3)
        {
            ScoreText3.text = "Writing Code: Basic - " + count_1+"%";
            score_WR = "Basic: "+count_1+"";
            sc_WR = count_1;
            minorB_WR = "Basic: "+count_1+"";
            minorI_WR = "Intermediate: "+count_2+"";
            minorP_WR = "Proficient: "+count_3+"";
        }else if(count_2 > count_1 & count_2 > count_3){
            ScoreText3.text = "Writing Code: Intermediate - " + count_2+"%";
            score_WR = "Intermediate: "+count_2+"";
            sc_WR = count_2;
            minorB_WR = "Basic: "+count_1+"";
            minorI_WR = "Intermediate: "+count_2+"";
            minorP_WR = "Proficient: "+count_3+"";
        }else if(count_3 > count_1 & count_3 > count_2)
        {
            ScoreText3.text = "Writing Code: Proficient - " + count_3+"%";
            score_WR = "Proficient: "+count_3+"";
            sc_WR = count_3;
            minorB_WR = "Basic: "+count_1+"";
            minorI_WR = "Intermediate: "+count_2+"";
            minorP_WR = "Proficient: "+count_3+"";
        }else if(count_1 == 33 & count_2 == 33 & count_3 == 33) {
                ScoreText3.text = "Writing Code: Basic: 33%";
                score_WR = "Basic: 33";
                sc_WR = count_1;
                minorB_WR = "Basic: "+count_1+"";
                minorI_WR = "Intermediate: "+count_2+"";
                minorP_WR = "Proficient: "+count_3+"";
        }else if(count_1 == 66 & count_2 == 66 & count_3 == 66) {
                ScoreText3.text = "Writing Code: Intermediate: 66%";
                score_WR = "Intermediate: 66";
                sc_WR = count_2;
                minorB_WR = "Basic: "+count_1+"";
                minorI_WR = "Intermediate: "+count_2+"";
                minorP_WR = "Proficient: "+count_3+"";
        }else if(count_1 == 99 & count_2 == 99 & count_3 == 99) {
                ScoreText3.text = "Writing Code: Proficient: 99%";
                score_WR = "Proficient: 99";
                sc_WR = count_3;
                minorB_WR = "Basic: "+count_1+"";
                minorI_WR = "Intermediate: "+count_2+"";
                minorP_WR = "Proficient: "+count_3+"";
        }
        
    }

    public void a_EX(List<int> l_EX)
    {
        count_1 = 0;
        count_2 = 0;
        count_3 = 0;
        foreach (int x in l_EX)
        {
            if(x==1)
            {
                count_1 = count_1 + 33;
            }else if(x==2)
            {
                count_2 = count_2 + 33;
            }else if(x==3)
            {
                count_3 = count_3 + 33;
            }
        }

        if(count_1 > count_2 & count_1 > count_3)
        {
            ScoreText4.text = "Explaining/Discussing Code: Basic - " + count_1+"%";
            score_EX = "Basic "+count_1+"";
            sc_EX = count_1;
            minorB_EX = "Basic: "+count_1+"";
            minorI_EX = "Intermediate: "+count_2+"";
            minorP_EX = "Proficient: "+count_3+"";
        }else if(count_2 > count_1 & count_2 > count_3){
            ScoreText4.text = "Explaining/Discussing Code: Intermediate - " + count_2+"%";
            score_EX = "Intermediate: "+count_2+"";
            sc_EX = count_2;
            minorB_EX = "Basic: "+count_1+"";
            minorI_EX = "Intermediate: "+count_2+"";
            minorP_EX = "Proficient: "+count_3+"";
        }else if(count_3 > count_1 & count_3 > count_2)
        {
            ScoreText4.text = "Explaining/Discussing Code: Proficient - " + count_3+"%";
            score_EX = " Proficient: "+count_3+"";
            sc_EX = count_3;
            minorB_EX = "Basic: "+count_1+"";
            minorI_EX = "Intermediate: "+count_2+"";
            minorP_EX = "Proficient: "+count_3+"";
        }else{
            ScoreText4.text = "Explaining/Discussing Code: Basic: 33%";
            score_EX = "Basic: 33";
            sc_EX = count_1;
            minorB_EX = "Basic: "+count_1+"";
            minorI_EX = "Intermediate: "+count_2+"";
            minorP_EX = "Proficient: "+count_3+"";
        }
        
    }

    

    

    int num = 0;

    
    public string user_data;
    public string user_data1;

    
    public void SavePlayer()
    {
        trans.SetTrigger("Start");
        PlayerData data = SaveSystem.LoadPlayer();
        PlayerData data1 = SaveSystem.LoadPlayer1();
        tem_ME = score_ME;
        tem_TS = score_TS;
        tem_EX = score_EX;
        tem_WR = score_WR;
        tem_SL = score_SL;
        tem_TP = score_TP;
        tem_save = time_save;
        Debug.Log(tem_save);
        try{
            user_data = data.user_n;
            user_data1 = data1.user_n;
        }catch (NullReferenceException ex){
            Debug.Log("No Loaded data");
            SaveSystem.SavePlayer(this);
            Debug.Log("data SAVED AT 1ST");
            SaveSystem.SavePlayer1(this);
            Debug.Log("data SAVED AT 2ND");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(user_data == null)
        {
            SaveSystem.SavePlayer(this);
            Debug.Log("data SAVED AT 1ST");
            SaveSystem.SavePlayer1(this);
            Debug.Log("data SAVED AT 2ND");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }else{
            do{
            //Debug.Log(data1.user_n);
            gamer.user_n = data1.user_n;
            score_ME = data1.ME;
            score_TS = data1.TS;
            score_EX = data1.EX;
            score_WR = data1.WR;
            score_SL = data1.SL;
            score_TP = data1.timerpressure;
            time_save = data1.time_s;

            Debug.Log(score_ME);
            Debug.Log(score_TS);
            Debug.Log(score_EX);
            Debug.Log(score_WR);
            Debug.Log(score_SL);
            Debug.Log(data1.time_s);
            Debug.Log("Data Saved in Last");
            SaveSystem.SavePlayer(this);

            score_ME = tem_ME;
            score_TS = tem_TS;
            score_EX = tem_EX;
            score_WR = tem_WR;
            score_SL = tem_SL;
            score_TP = tem_TP;
            time_save = tem_save;
            Debug.Log(score_ME);
            Debug.Log(score_TS);
            Debug.Log(score_EX);
            Debug.Log(score_WR);
            Debug.Log(score_SL);
            num++;
            }while(num != 1);

            gamer.user_n = username.ToString();
            gamer.ME = score_ME;
            gamer.TS = score_TS;
            gamer.EX = score_EX;
            gamer.WR = score_WR;
            gamer.SL = score_SL;
            gamer.timerpressure = score_TP;
            gamer.time_s = time_save;
            Debug.Log(gamer.user_n);
            Debug.Log(gamer.ME);
            Debug.Log(gamer.TS);
            Debug.Log(gamer.EX);
            Debug.Log(gamer.WR);
            Debug.Log(gamer.SL);
            Debug.Log(gamer.time_s);
            SaveSystem.SavePlayer1(this);

            Debug.Log("load LAST SAVE");
            Debug.Log(data.ME);
            Debug.Log(data.TS);
            Debug.Log(data.EX);
            Debug.Log(data.WR);
            Debug.Log(data.SL);
            Debug.Log("LOAD LATEST SAVE");
            Debug.Log(data1.ME);
            Debug.Log(data1.TS);
            Debug.Log(data1.EX);
            Debug.Log(data1.WR);
            Debug.Log(data1.SL);

            Debug.Log("Data Saved in Latest");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
        
    }
}
