using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitController : MonoBehaviour
{
    GameObject MGauge;

    float[] notesX  = new float[10];
    float hitZornX = 0;
    int notesNum = 0;

    public float perArea;
    public float exceArea;
    public float goodArea;
    public float badArea;

    public int decision = 0;
    const int Perfect = 4;
    const int Excellent = 3;
    const int Good = 2;
    const int Bad = 1;

    public bool Hit = false;
    public bool getEndHit = false;
    public bool getMTime = false;

    public AudioClip HitSE;
    AudioSource aud;
    public HitDirector HitDirScript;
    public MomentaryGauge MGaugeScript;

    // Use this for initialization
    void Start()
    {
        MGauge = GameObject.Find("MomentaryGauge");
        MGaugeScript = MGauge.GetComponent<MomentaryGauge>();

        hitZornX = transform.position.x;
        aud = GetComponent<AudioSource>();
        HitDirScript = GetComponent<HitDirector>();
    }

    //ノーツの判定を取る
    void HitNotes()
    {
        if (notesX[notesNum] <= (hitZornX + perArea) && notesX[notesNum] >= (hitZornX - perArea))
        {
            decision = Perfect;
        }

        else if (notesX[notesNum] <= (hitZornX + exceArea) && notesX[notesNum] >= (hitZornX - exceArea))
        {
            decision = Excellent;
        }

        else if (notesX[notesNum] <= (hitZornX + goodArea) && notesX[notesNum] >= (hitZornX - goodArea))
        {
            decision = Good;
        }

        else if (notesX[notesNum] <= (hitZornX + badArea) && notesX[notesNum] >= (hitZornX - badArea))
        {
            decision = Bad;
        }
    }

    //Score,Gauge加算が終わったらリセットする
    public void NotesReset()
    {
        if(Hit)
        {
            decision = 0;
            Hit = false;
        }
    }

    //NotesノーツがHitZornに重なり、Spaceが押されたとき
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Notes")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                notesX[notesNum] = other.gameObject.transform.position.x;
                HitNotes();
                Hit = true;
                MGaugeScript.MTime = false;
                this.aud.PlayOneShot(this.HitSE);
                
                Destroy(other.gameObject);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}