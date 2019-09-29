using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScript : MonoBehaviour {

    GameObject HitZorn;

    public int comboCount = 0;
    int inCount = 0;
    int getDecision = 0;

    public bool endCombo = false;

    public HitController HitCon;
    public Text ComboTx;
    
	// Use this for initialization
	void Start () {
        HitZorn = GameObject.Find("HitZorn");

        HitCon = HitZorn.GetComponent<HitController>();
    }

    //Comboの継続条件
    void ComboCount()
    {
        getDecision = HitCon.decision;

        switch(getDecision)
        {
            case 1:
                comboCount = 0;
                inCount++;
                endCombo = true;
                break;

            case 2:
                comboCount++;
                inCount++;
                endCombo = true;
                break;

            case 3:
                comboCount++;
                inCount++;
                endCombo = true;
                break;

            case 4:
                comboCount++;
                inCount++;
                endCombo = true;
                break;

            default:
                endCombo = false;
                break;
        }
    }

    //Comboの表示
    void InCount()
    {
        if(!endCombo)
        {
            inCount = 0;
        }

        if (inCount == 0)
        {
            ComboCount();
            ComboTx.text = this.comboCount.ToString() + "Combo";
        }
    }

    // Update is called once per frame
    void Update () {
        InCount();
    }
}
