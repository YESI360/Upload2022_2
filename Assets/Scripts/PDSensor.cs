using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class PDSensor : MonoBehaviour
{
    public int Up;
    public int Down;
    public LibPdInstance pdPatch;

    public GameObject cylinder;
    public AudioSource PDSound;
    public float Speed;
    void Start()
    {
        GetComponent<AudioSource>().volume = 0.3f;// 0.5f;
    }
    public void VolumenUp()
    {
        PDSound.volume += Time.deltaTime * Speed;
    }

    public void SoundUp()
    {
        cylinder.transform.localScale = new Vector3(Up, Up, Up) * Time.deltaTime;
        pdPatch.SendFloat("proximity", Up);
    }

    public void increaseUp()
    {
        Up++;
    }

    public void SoundDown()
    {
        cylinder.transform.localScale = new Vector3(Down, Down, Down) * Time.deltaTime;
        pdPatch.SendFloat("proximity", Down);
    }


}
