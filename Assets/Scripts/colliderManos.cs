using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderManos : MonoBehaviour
{
    //public bool InAvatar;
    public ShaderSB3 limit;//alCollider se pone TRUE "LUZLIMIT"

    public void OnTriggerEnter (Collider other)
    //public void OnTriggerEnter(Collider other)//mano toca guia ONTRIGGERSTAY?//
    {
        if (other.CompareTag("objGuia") )// && !InAvatar)//|| collider.gameObject.tag == "objGuia")
        {
            //InAvatar = true;

            Debug.Log("SE TOCAN Y TRUE");//se repite!!! que suceda solo 1 vez

            if(!SoundManagerGuia.instance.IsPlaying && limit.alCollider == true)//solo dsd "LUZLIMIT"
                SoundManagerGuia.instance.PlayInstruccion05();//put hands waits

            //si PONGO MANOS CINTURA activa collider capsule "tocar3"
            //avatar.mirrorFake(); //veo avatar fake 8 

            //flow.SetState(GameState1.Belly1);//////////////////////////         

        }
    }

    private void OnTriggerExit(Collider other)
    {

    //    if (other.CompareTag("objGuia") && InAvatar)//|| collider.gameObject.tag == "objGuia")
    //    {
    //        InAvatar = false;
    //        SoundManagerGuia.instance.Stop();
    //    }
    }
}

    