using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB3 : MonoBehaviour
{
    Renderer rend;
    public float manosLim;//0.147
    public float manosLim2;//0.185

    public float mirrorLimt;//0.223
    public float mirrorLimt2;//0.262

    public float luzLimt;//0.301
    public float luzLimt2;//0.351

    public float guiaStandup;//0.401
    public float guiaAvatar;//0.555
    public float bellyLimt;//0.633
    public PointerEvents gaze;

    public LuzAmb luzAmb;
    public LuzGuia luzguia;
    public tocar3 espejo;
    public ChangeMat avatar;
    public PDSensorSHARED pd;
    public colliderManos touch;
    public activarColliderGuia colliderOnG;
    public activarColliderManoR colliderOnR;
    public activarColliderManoL colliderOnL;

    public int steps = 10;
    public float targetValueDownIncreaseStep;
    public float targetValueUp;
    public float targetValueDown;

    public float MaxContribution;
    public float MinContributionNew;//start in black
    public int MinContributionCount;
    public float VelContribution;
    public float currentValue;
    [Range(0.210f, 1)] public float lerpedValue;

    public float lerpSpeedUp;
    public float lerpSpeedDown;
    private float lerpSpeedUpNew;
    private float lerpSpeedUpCount;
    public float lerpSpeedUpVel;

    public AudioSource instrIni;
    public float delay = 2;
    public float volume = 0.5f;

    public bool instruccionIni;
    public bool InHands;
    public bool InMirror;
    public bool InLuzamb;
    public bool InGuia;
    //public bool InAvatar;///
    public bool InStandup;
    public bool alCollider;

    public FlowMan flow;

    public MyMessageListenerSHARED contador;
    //private void Awake()//NO FUNCIONA
    //{
    //    flow.SetState(GameState1.NotStarted1);
    //}

    void Start()
    {      
        instrIni.PlayDelayed(delay);
        
        InHands = true;
        InMirror = true;
        InLuzamb = true;
        InGuia = true;
        //InAvatar = true;
        InStandup = true;

        targetValueDownIncreaseStep = (targetValueUp - targetValueDown) / steps;
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_ZeroValue");

        MaxContribution = 1;
        targetValueUp = 1;
        targetValueDown = 0;
        MinContributionNew = 0.181f;//0.210f; //=1 resp
        lerpSpeedUpCount = 0;
        MinContributionCount = 0;

        /*
        if (touch.guia == true )//&& InAvatar && !SoundManagerGuia.instance.IsPlaying) //MinContributionNew >= luzLimt && 
        {
            Debug.Log("se tocaron");
            SoundManagerGuia.instance.PlayInstruccion05();
            InAvatar = false;
        }
   /////////////////////
        if ( touch.setocaron () == true )
        { 
        }
        */
    }

    void Update()
    {
        if (Input.GetKeyDown("1")) // (Input.GetKeyDown("1"))//
        {
            MinContributionNew = 0.454f;
            Debug.Log("ver");
        }

        if (Time.timeSinceLevelLoad <= delay || instrIni.isPlaying)
            return;
        if (flow.CurrentState1 == GameState1.NotStarted1)
            flow.SetState(GameState1.Chest1);

        if (Input.GetKeyDown("q"))
        {
            instrIni.Play();
        }

    }

    public void LuzUp()
    {
        lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUpNew);
        currentValue = Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution);
        rend.material.SetFloat("_ZeroValue", currentValue);

        lerpSpeedUpCount = lerpSpeedUpCount + 1; // So you add to the count everytime you go into this function, if it executes once when you have a new breath
        lerpSpeedUpNew = lerpSpeedUpCount * lerpSpeedUpVel; // So this increases by 0.2f everytime this function is called

        MinContributionCount = MinContributionCount + 1;
        MinContributionNew = MinContributionCount * VelContribution;


        if (MinContributionNew >= manosLim && MinContributionNew <= manosLim2 && InHands && !SoundManagerGuia.instance.IsPlaying)//&& MinContributionNew < 0.09f && instructions == 0)
        {    ///////////////////////0.147                   
            Debug.Log("manosAIR"); //luzHands [my messLis]
            SoundManagerGuia.instance.PlayInstruccion01();//where AIR?
            InHands = false;
        }


        if (MinContributionNew >= mirrorLimt && MinContributionNew <= mirrorLimt2 && InMirror && !SoundManagerGuia.instance.IsPlaying)
        {//////////////////////////0.223
            espejo.planeMirror.SetActive(true);
            Debug.Log("espejoReal");
            SoundManagerGuia.instance.PlayInstruccion02();//AIR ENTER AIR OUT
            InMirror = false;
        }

        if (MinContributionNew >= luzLimt  && InGuia && !SoundManagerGuia.instance.IsPlaying)//&& MinContributionNew <= luzLimt2
        {///////////////////////////////0.301
            luzguia.luzUpGuia();////////////////////////////1
            luzAmb.luzUp();///////////////////////////////////////////////A
            Debug.Log("luzAmb1");
            ////////si Luzguia TOCA Luzmano
            SoundManagerGuia.instance.PlayInstruccion03();//ITS ME! ||-NO TOCO, SOLO SALUDO-
            InGuia = false;
            colliderOnG.agrandarCollider();////agrando collider GUIA
            alCollider = true;//////////////////aviso al collider que se puede activar recien aca
        }//no mas input breath!(va a seguir afectando el shader pero sin trigeriar nada)

        //MIRAR GUIA Y PLAY INSTRUCCION04 take my hand

        if (gaze == true && InStandup && !SoundManagerGuia.instance.IsPlaying)
        {
            luzAmb.luzUp();///////////////////////////////////////////
            Debug.Log("standUp");
            InStandup = false;
            ////////al collider=TRUE reproduce INSTRUCCION5 put hands waits
            colliderOnL.agrandarCollidermanoL();////agrando collider MANOS para que toqen guia+mano
            colliderOnR.agrandarCollidermanoR();// y luego manos+capsula
        }

        /*
        //input gaza NO MinContributionNew >= guiaStandup...
        //if GAZE && !SoundManagerGuia.instance.IsPlaying
        if (MinContributionNew >= guiaStandup && InStandup && !SoundManagerGuia.instance.IsPlaying )//&& touch.guia == true)
            {//INSTRUCCION 04 POR GAZE//////0.401
                   luzAmb.luzUp();//////////////////////////////////////////////B
                   Debug.Log("standUp");
            //SoundManagerGuia.instance.PlayInstruccion04();// //TAKE ME HAND, STAND UP
            InStandup = false;
            colliderOnL.agrandarCollidermanoL();
            colliderOnR.agrandarCollidermanoR();
        }
        */
        ////////YO TOCO Y COLISIONO
        ////VOY AL CODIGO colliderManos Y PlayInstruccion05();//put hands waits [IF alCollider = true]


        var potentialNextValue = Mathf.Clamp(targetValueDown + targetValueDownIncreaseStep, 0, targetValueUp);
        if (currentValue >= potentialNextValue)
        {
            targetValueDown = potentialNextValue;
        }

    }


    public void LuzDown()
    {

        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution));

        currentValue = rend.material.GetFloat("_ZeroValue");
    }

}
