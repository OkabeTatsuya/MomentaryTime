using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDirector : MonoBehaviour {

    GameObject HitZorn;
    GameObject Score;
    GameObject MGauge;
    GameObject Combo;

    bool getHit = false;
    bool getEndScore = false;
    bool getEndMoment = false;
    bool getEndCombo = false;

    public bool endHit = false;

    public HitController HitContScript;
    public ScoreCount ScoreScript;
    public MomentaryGauge MGaugeScript;
    public ComboScript ComScript;

    // Use this for initialization
    void Start () {
        HitZorn = GameObject.Find("HitZorn");
        Score = GameObject.Find("Score");
        MGauge = GameObject.Find("MomentaryGauge");
        Combo = GameObject.Find("Combo");

        HitContScript = HitZorn.GetComponent<HitController>();
        ScoreScript = Score.GetComponent<ScoreCount>();
        MGaugeScript = MGauge.GetComponent<MomentaryGauge>();
        ComScript = Combo.GetComponent<ComboScript>();
    }

    //判定の情報をリセットした後、終了判定をリセット
    void EndPlus()
    {
        getHit = HitContScript.Hit;
        if(getHit)
        {
            getEndScore = ScoreScript.endScore;
            getEndMoment = MGaugeScript.endUp;
            getEndCombo = ComScript.endCombo;

            if ((getEndScore == true && getEndMoment == true && getEndCombo == true))
            {
                HitContScript.NotesReset();
                TrueEndHit();
            }
        }
    }

    //送られてきた処理の終了判定をリセットする
    void TrueEndHit()
    {
        ScoreScript.endScore = false;
        MGaugeScript.endUp = false;
        ComScript.endCombo = false;
    }

    // Update is called once per frame
    void Update () {
        EndPlus();
    }
}
