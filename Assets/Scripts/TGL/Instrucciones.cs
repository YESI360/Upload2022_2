using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Instrucciones : MonoBehaviour
{
    [SerializeField] int CantidadDeVidosIntruccion_1;
    [SerializeField] int CantidadDeVidosIntruccion_3;
    [SerializeField] SpawnerGeneral spawnScript;
    [SerializeField] MicControlC mic;
    [SerializeField] float minLoudnessDetection = 0.02f;
    [SerializeField] AudioSource audioS;
    [SerializeField] AudioClip[] clips;
    [SerializeField] LevelManager levelManager;//NO
    [SerializeField] AudioMixer audioMixer;
    public FlowManCITY flow;

    public PDSensorSHARED synth;
    public movDER volumenD;
    public movIZQ volumenI;

    public int instructions = 0;
    float targetVolumen = 0;
    public float currentVolumen = 0;
    public int delay;
    private int steps;


    private void Start()
    {
        //audioS.clip = clips[instructions];
        audioS.PlayDelayed(10);
    }
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    instructions = spawnScript.DestroyEntities(3);
        //}
        if (currentVolumen != targetVolumen)
        {
            currentVolumen = Mathf.Lerp(currentVolumen, targetVolumen, .5f * Time.deltaTime);
            audioMixer.SetFloat("musicVol", Mathf.Lerp(currentVolumen, targetVolumen, .5f * Time.deltaTime));
        }

        if (audioS.isPlaying)
            return;

        if ((mic.loudness > minLoudnessDetection)/*Input.GetMouseButtonDown(0)*/)//
        {
            if (instructions == 0)//00 
            {
                //flow.SetState(GameState0.Chest0);
                print("Instruccion 1 completada");
                volumenD.VolumenDown();
                volumenI.VolumenDown();
                instructions = 1;
                currentVolumen = 0;
                targetVolumen = -10f;
                audioS.clip = clips[instructions - 1];
                audioS.PlayDelayed(delay);
                spawnScript.DestroyEntities(CantidadDeVidosIntruccion_1);
                return;
            }

            if (instructions == 1)//01b
            {
                print("Instruccion 2 completada");
                synth.VolumenUp();    ///////////////////          
                volumenD.VolumenDown();
                volumenI.VolumenDown();
                volumenI.MoveGameObject2();///no funciona
                instructions = 2;
                currentVolumen = -10;
                targetVolumen = -17f;
                audioS.clip = clips[instructions - 1];
                audioS.PlayDelayed(delay);
                spawnScript.ChangeAnimation();
                Debug.Log("ANIM");
                return;
            }

            if (instructions == 2)// 02b
            {
                print("Instruccion 3 completada");
                synth.VolumenUp();  ////////////////////
                synth.SoundUp();              
                instructions = 3;
                currentVolumen = -17;
                targetVolumen = -25f;
                audioS.clip = clips[instructions - 1];
                audioS.PlayDelayed(delay);//10
                spawnScript.DestroyEntities(CantidadDeVidosIntruccion_3);
                return;
            }
        }

        if (instructions == 3)//03 TRANS
        {
            synth.SoundUp();
            //print("NextLevel");

            steps++;
            //Debug.Log("step : " + steps);

            if (steps >= 75) 
            {
                SteamVR_LoadLevel.Begin("0222CalibrationBLACK-shader");
                levelManager.LoadNextLevel();//para usar key?
                flow.SetState(GameState0.NotStarted0);
                
            }

        }
    }

}
