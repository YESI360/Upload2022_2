﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanzaOK : MonoBehaviour
{
    Light myLight;
    public FlowManager flowB;

    public AudioSource InstruccionBelly2;
    public AudioClip clip;
    public float volume = 0.5f;
    public bool IsPlaying => InstruccionBelly2.isPlaying;
    public float range;
    public float rangeMult;
    public float speed;
    public float maxpos;
    public float maxneg;
    
    private int step;

    public int Inhalelenght;
    public bool instrBelly;


    void Start()
    {
       //myLight.enabled = false;
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
        instrBelly = true;
    }

    void Update ()
    {

        if (Input.GetKeyDown("l") || flowB.CurrentState == GameState.Belly)
        {
            //myLight.intensity = 0;
            myLight.enabled = true;
        }
                if (Input.GetKeyDown("k"))
        {
            myLight.enabled = false;
        }

    }
  

    public void inflaPanza()
    {
        //myLight.enabled = true;
        myLight.range += range * rangeMult * Time.deltaTime;//IMPORTA MAS RANGE
        myLight.intensity = Mathf.Lerp(myLight.intensity, maxpos, speed * Time.deltaTime);

        //if (flowB.CurrentState == GameState.Belly)
        //{
           // myLight.enabled = true;
           // myLight.range += range * rangeMult * Time.deltaTime;//IMPORTA MAS RANGE
           // myLight.intensity = Mathf.Lerp(myLight.intensity, maxpos, speed * Time.deltaTime);
        //}
  
        step++;
        //lenght.text = "dur: " + step;

        if (step >= Inhalelenght && !InstruccionBelly2.isPlaying && instrBelly) //  //!SoundManager.instance.IsPlaying
        {
            InstruccionBelly2.PlayOneShot(clip, volume);
            //stepAnt = step;
            instrBelly = false;
        }
        //Debug.Log("step : " + step);
        //step = stepAnt;
        //stepAnt = step;



    }
    public void desinflaPanza()
    {
        myLight.range = Mathf.Lerp(myLight.range, maxneg, speed * Time.deltaTime); 
        myLight.intensity = Mathf.Lerp(myLight.intensity, maxneg, speed * Time.deltaTime);//le hago sped y max-min para range separado de intensity??
        //Debug.Log("panza off");
    }



}
