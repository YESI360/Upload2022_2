using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManos1 : MonoBehaviour
{
    public bool hand1;//f

    /////este script esta porque las manos se tocan entre si porque "nacen" juntos (0,0,0) y pasa a TRUE

    void Start()
    {       
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
        } 
            
    }




 }

    