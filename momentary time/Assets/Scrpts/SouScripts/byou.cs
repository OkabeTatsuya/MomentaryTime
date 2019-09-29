using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class byou : MonoBehaviour {

    GameObject timerText;
    public float time = 60.0f;

    

	// Use this for initialization
	void Start () {
        this.timerText = GameObject.Find("Time");
        
	}
	

	// Update is called once per frame
	void Update () {
        
        this.time -= Time.deltaTime;

        this.timerText.GetComponent<Text>().text =
            this.time.ToString("F1");
	if (time < 0f)
    {

        time = 0f;

    }
}


  

}




  
   