using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public string user_n;
    public string ME;
    public string TS;
    public string EX;
    public string WR;
    public string SL;
    public string timerpressure;

    public string time_s;

    //int for profile
    public int sc_EX_save;
    public int sc_ME_save;
    public int sc_TS_save;
    public int sc_WR_save;
    public int sc_SL_save;
    public float sc_TP_save;

    //minor scores
    public string mB_ME;
    public string mI_ME;
    public string mP_ME;

    public string mB_TS;
    public string mI_TS;
    public string mP_TS;

    public string mB_EX;
    public string mI_EX;
    public string mP_EX;

    public string mB_WR;
    public string mI_WR;
    public string mP_WR;

    public string mB_SL;
    public string mI_SL;
    public string mP_SL;


    public PlayerData(QuizManager Quiz_Manager)
    {
        user_n = Quiz_Manager.call_user;
        time_s = Quiz_Manager.time_save;
        ME = Quiz_Manager.score_ME;
        TS = Quiz_Manager.score_TS;
        EX = Quiz_Manager.score_EX;
        WR = Quiz_Manager.score_WR;
        SL = Quiz_Manager.score_SL;
        timerpressure = Quiz_Manager.score_TP;

        mB_ME = Quiz_Manager.minorB_ME;
        mI_ME = Quiz_Manager.minorI_ME;
        mP_ME = Quiz_Manager.minorP_ME;

        mB_TS = Quiz_Manager.minorB_TS;
        mI_TS = Quiz_Manager.minorI_TS;
        mP_TS = Quiz_Manager.minorP_TS;

        mB_EX = Quiz_Manager.minorB_EX;
        mI_EX = Quiz_Manager.minorI_EX;
        mP_EX = Quiz_Manager.minorP_EX;

        mB_WR = Quiz_Manager.minorB_WR;
        mI_WR = Quiz_Manager.minorI_WR;
        mP_WR = Quiz_Manager.minorP_WR;

        mB_SL = Quiz_Manager.minorB_SL;
        mI_SL = Quiz_Manager.minorI_SL;
        mP_SL = Quiz_Manager.minorP_SL;

        sc_ME_save = Quiz_Manager.sc_ME;
        sc_EX_save = Quiz_Manager.sc_EX;
        sc_TS_save = Quiz_Manager.sc_TS;
        sc_SL_save = Quiz_Manager.sc_SL;
        sc_WR_save = Quiz_Manager.sc_WR;
        sc_TP_save = Quiz_Manager.totalperc;
    }
}
