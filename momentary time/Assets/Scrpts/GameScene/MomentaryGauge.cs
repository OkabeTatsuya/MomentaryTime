using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MomentaryGauge : MonoBehaviour {
    GameObject HitZorn;
    GameObject momentaryObj;

    public int MCount = 0;
    int getDecision = 0;
    int inCount = 0;

    public bool endUp = false;
    public bool MTime = false;
    public bool LedyMTime = false;

    public HitController HitCon;
    public Image MGTx;

    // Use this for initialization
    void Start() {
        HitZorn = GameObject.Find("HitZorn");
        momentaryObj = GameObject.Find("MomentaryGauge");

        HitCon = HitZorn.GetComponent<HitController>();
        MGTx = momentaryObj.GetComponent<Image>();
    }

    //判定によってMomentaryGaugeの上場量を決定する
    void GaugeUp()
    {
        getDecision = HitCon.decision;

        switch (getDecision)
        {
            case 1:
                endUp = true;
                break;

            case 2:
                MCount += 1;
                endUp = true;
                break;

            case 3:
                MCount += 2;
                endUp = true;
                break;

            case 4:
                MCount += 3;
                endUp = true;
                break;

            default:
                break;
        }
    }

    //10溜まったらギリギリTime突入、終わったらMCountをリセット
    void InMTime()
    {
        if (MCount >= 10)
        {
            LedyMTime = true;
        }
        else
        {
            LedyMTime = false;
        }
    }

    void InCount()
    {
        if (!endUp)
        {
            inCount = 0;
        }

        if (inCount == 0)
        {
            GaugeUp();
            MGTx.color = new Color(1, 1, 1, 0.1f * MCount);
            inCount++;
        }
    }

    // Update is called once per frame
    void Update () {
        InCount();
        InMTime();
    }
}
