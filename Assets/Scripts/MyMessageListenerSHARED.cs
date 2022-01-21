using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;
using Valve.VR;

public class MyMessageListenerSHARED : MonoBehaviour
{
    //public GUILabelsCITY label;
    public int enableSB;
    public GameObject sphereBelly;
    public GameObject sphereChest;
    public PDSensorSHARED pdScript;//chest de la escenaCITY
    public LuzBelly luzB;//de la escenaCAL
    public ShaderSB3 luzSB;//de la escenaCAL
    //public SoundManagerGuia instrucciones;
    public LuzHandL luzmanoL;
    public LuzHandR luzmanoR;

    public Vector3 maxLocalScale;
    float maxlocalScaleMagnitude;

    public Text belly;
    public Text chest;

    public float datoNormCC;
    public float datoNormCB;
    public int datoL = 0;
    private int datoLant = 1;
    public int datoL2 = 0;
    string[] vec1;

    public FlowMan flow;
    public FlowManCITY flowC;

    public int stepB;
    public int stepsAnt1 = 0;

    public int entradaBelly;
    public int contadorLevel;

    private void Start()
    {
        maxLocalScale = new Vector3(3, 3, 3);
        maxlocalScaleMagnitude = maxLocalScale.magnitude;
    }

    private void Awake()
    {
        Initialize();
    }

    private void OnLevelWasLoaded(int level)
    {
        Initialize();
    }

    void Update() //botonera INPUT SENSOR //Arrows
    {       
        if (Input.GetKey(KeyCode.UpArrow))//CHEST2 INHALA 
        {
            datoL2 = 2;
        }
        if (Input.GetKey(KeyCode.DownArrow))//CHEST1 EXHALA
        {
            datoL2 = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))//BELLY INHALA
        {
            datoL = 2;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//BELLY EXHALA
        {
            datoL = 1;
        }        
    }


    public void OnMessageArrived(string msg)
    {
        //Debug.Log("Arrived: " + msg);
        vec1 = msg.Split(',');
        string c1 = "chest";
        string c2 = (vec1[0]);
        string b1 = "belly";
        string n1 = "CC";
        string n2 = "CB";

        if ((String.Compare(c1, c2)) == 0)//chest to vec
        {
            datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
            //Debug.Log("chest:" + datoL2);
        }
        else if ((String.Compare(b1, c2)) == 0)//belly to vec
        {
            datoL = (Convert.ToInt32(vec1[1]));//belly  
            //Debug.Log("belly:" + datoL);
        }
        else if ((String.Compare(n1, c2)) == 0)//norm to vec
        {
            datoNormCC = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCC);
        }
        else if ((String.Compare(n2, c2)) == 0)//norm to vec
        {
            datoNormCB = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCB);
        }
        ///////////////////////////////////////////////txt 
        belly.text = "belly: " + datoL;
        chest.text = "chest: " + datoL2;
        //////////COMENTAR PARA USAR [SOLO] ESCENA 2///////DESCOMENTAR PARA USAR TODO DE CORRIDO/////////////////////////////////////////////////////////////////////////////////////////////////
        //if (datoL2 == 2 && flowC.CurrentState0 == GameState0.Chest0)
        //{
        //    pdScript.SoundUp();
        //    //Debug.Log("pdCITY");
        //}
        //else { pdScript.SoundDown(); }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (flow != null)
        {
            ///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
            if (datoL2 == 2 && flow.CurrentState1 == GameState1.Chest1 )//|| flowC.CurrentState0 == GameState0.Chest0) 
            {

                pdScript.SoundUp();

                float actualLocalScaleMagnitude = transform.localScale.magnitude;
                if (actualLocalScaleMagnitude < maxlocalScaleMagnitude)
                {
                    sphereChest.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);
                    //transform.localScale += new Vector3(0.1F, 0.1F, 0);
                }

                //luzSB.LuzUp();
                if (luzSB != null)
                {
                    luzSB.LuzUp();
                }
                //luzmanoL.luzHandL();
                if (luzmanoL != null)
                {
                    luzmanoL.luzHandL();
                }
                //luzmanoR.luzHandR();
                if (luzmanoR != null)
                {
                    luzmanoR.luzHandR();
                }
            }
            else
            {
                pdScript.SoundDown();
                sphereChest.transform.localScale = new Vector3(3, 3, 3) * 2 * (Time.deltaTime);

                //luzSB.LuzDown();
                if (luzSB != null)
                {
                    luzSB.LuzDown();
                }
            }

            ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
            if (datoL != datoLant && flow.CurrentState1 == GameState1.Belly1 && !SoundManagerGuia.instance.IsPlaying)//(datoL == 2 && flow.CurrentState1 == GameState1.Belly1)
            {
                //entradaBelly = entradaBelly + 1;
                //Debug.Log("CONTADOR : " + entradaBelly);

                stepB++;
                datoLant = datoL;

                Debug.Log("STEPS : " + stepB);
                    
                    if (stepB == 2)
                    {
                        SoundManagerGuia.instance.PlayInstruccion07();//feel move
                    }
                    else if (stepB == 4)
                    {
                        SoundManagerGuia.instance.PlayInstruccion08();//gesture
                    contadorLevel++;

                    if (contadorLevel > 4)
                    {
                        SteamVR_LoadLevel.Begin("03ForestNEW");
                    }
                    

                    }
                else if (stepB == 6)
                {
                    SteamVR_LoadLevel.Begin("03ForestNEW");
                }


                //if (stepB == 6)
                //{
                //    SteamVR_LoadLevel.Begin("03ForestNEW");
                //    return;
                //}
                //datoLant = datoL;
                //stepsAnt1 = stepB;
            }
            

            if (datoL == 2 && flow.CurrentState1 == GameState1.Belly1)
            {
                if (luzB != null)
                {
                    luzB.luzUpBELLY();
                }
            }
            else
            {
                if (luzB != null)
                {
                    luzB.luzDownB();
                }
            }
        }
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }

    private void Initialize()
    {
        luzB = FindObjectOfType<LuzBelly>();
        luzSB = FindObjectOfType<ShaderSB3>();
        luzmanoL = FindObjectOfType<LuzHandL>();
        luzmanoR = FindObjectOfType<LuzHandR>();
        flow = FindObjectOfType<FlowMan>();
        //label = FindObjectOfType<GUILabelsCITY>();
    }
}
