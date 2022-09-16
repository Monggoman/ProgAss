using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Testing : MonoBehaviour
{
    [SerializeField] private UI_StatsRadarChart uiStatsRadarChart;

    public int ME_sc;
    public int TS_sc;
    public int SL_sc;
    public int EX_sc;
    public int WR_sc;
    public int TP_sec;

    public string user_data;

    private void Start()
    {

        PlayerData data = SaveSystem.LoadPlayer1();
        try{
             user_data = data.user_n;
        }catch (NullReferenceException ex){
            Debug.Log("No Loaded data");
        }

        ME_sc = data.sc_ME_save;
        TS_sc = data.sc_TS_save;
        SL_sc = data.sc_SL_save;
        EX_sc = data.sc_EX_save;
        WR_sc = data.sc_WR_save;
        TP_sec = Mathf.RoundToInt(data.sc_TP_save);

        Stats stats = new Stats(ME_sc, TS_sc, EX_sc, SL_sc, WR_sc, TP_sec);
        
        uiStatsRadarChart.SetStats(stats);
    }
}
