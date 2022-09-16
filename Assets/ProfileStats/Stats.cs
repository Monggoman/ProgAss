using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
    public event EventHandler OnStatsChanged;
    public static int STAT_MIN = 0;
    public static int STAT_MAX = 100;

    public enum Type
    {
        Mastery,
        Troubleshooting,
        Explanation,
        Selflearning,
        Writing,
        Pressure,
    }
    private SingleStat masteryStat;
    private SingleStat troubleshootingStat;
    private SingleStat explanationStat;
    private SingleStat selflearningStat;
    private SingleStat writingStat;
    private SingleStat pressureStat;

    public Stats(int masteryStatAmount, int troubleshootStatAmount, int explanationStatAmount, int selflearningStatAmount, int writingStatAmount, int pressureStatAmount)
    {
        masteryStat = new SingleStat(masteryStatAmount);
        troubleshootingStat = new SingleStat(troubleshootStatAmount);
        explanationStat = new SingleStat(explanationStatAmount);
        selflearningStat = new SingleStat(selflearningStatAmount);
        writingStat = new SingleStat(writingStatAmount);
        pressureStat = new SingleStat(pressureStatAmount);
    }

    private SingleStat GetSingleStat(Type statType)
    {
        switch (statType)
        {
            default:
            case Type.Mastery:          return masteryStat;
            case Type.Troubleshooting:  return troubleshootingStat;
            case Type.Explanation:      return explanationStat;
            case Type.Selflearning:     return selflearningStat;
            case Type.Writing:          return writingStat;
            case Type.Pressure:         return pressureStat;
        }
    }

    public void SetStatAmount(Type statType,int statAmount)
    {
        GetSingleStat(statType).SetStatAmount(statAmount);
        if (OnStatsChanged != null) OnStatsChanged(this, EventArgs.Empty);
    }
    public void IncreaseStatAmount(Type statType)
    {
        GetSingleStat(statType).IncreaseStatAmount();
    }
    public void DecreaseStatAmount(Type statType)
    {
        GetSingleStat(statType).DecreaseStatAmount();
    }
    public int GetStatAmount(Type statType)
    {
        return GetSingleStat(statType).GetStatAmount();
    }
    public float GetStatAmountNormalized(Type statType)
    {
        return GetSingleStat(statType).GetStatAmountNormalized();
    }


    private class SingleStat
    {
        private int stat;
        public SingleStat(int statAmount)
        {
            SetStatAmount(statAmount);
        }

        public void SetStatAmount(int statAmount)
        {
            stat = Mathf.Clamp(statAmount, STAT_MIN, STAT_MAX);
        }
        public void IncreaseStatAmount()
        {
            SetStatAmount(stat + 1);
        }
        public void DecreaseStatAmount()
        {
            SetStatAmount(stat - 1);
        }
        public int GetStatAmount()
        {
            return stat;
        }
        public float GetStatAmountNormalized()
        {
            return (float)stat / STAT_MAX;
        }
    }
}
