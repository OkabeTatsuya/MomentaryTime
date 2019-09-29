using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MTimeController : MonoBehaviour {
    GameObject MomentaryGauge;
    public MomentaryGauge MGScript;

    bool getLedy = false;
    public AudioClip MomentarySE;
    AudioSource aud;


    // Use this for initialization
    void Start () {
        MomentaryGauge = GameObject.Find("MomentaryGauge");
        MGScript = MomentaryGauge.GetComponent<MomentaryGauge>();
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        getLedy = MGScript.LedyMTime;
        if(other.gameObject.tag == "Notes")
        {
            if(getLedy)
            {
                this.aud.PlayOneShot(this.MomentarySE);
                MGScript.MTime = true;
                MGScript.MCount = 0;
                MGScript.LedyMTime = false;

            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
