using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManos1 : MonoBehaviour
{
    //public AudioSource audioSource;
    public bool hand1;//f

    /////se tocan porque nacen juntos y pasa a TRUE

    void Start()
    {       
        //guia = false;
    }


    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if ( other.CompareTag("hands2") )//|| collider.gameObject.tag == "objGuia")
        {
            Debug.Log("SE TOCAN Y TRUE");
            hand1 = true;
            //audioSource.Play();
        } 
            


    }




 }

    