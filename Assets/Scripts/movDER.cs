using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDER : MonoBehaviour
{
    public GameObject CubeVocesDER;
    public float movementSpeed;
    public float SpeedVol;
    public AudioSource Voces;

    private Vector3 target = new Vector3(-151, 139, -163);

    public void MoveGameObject()
    {
        
    }
    void Start()
    {
        GetComponent<AudioSource>().volume = 1;
        //GameObject.Find("gameObjectToMove").transform.position.X();
        //Vector3 pos1 = GameObject.Find("CubeVocesDER").transform.position;
    }

    public void VolumenDown()
    {
        Voces.volume -= Time.deltaTime * SpeedVol;
        //Voces.volume = 0.6f;
    }


    void Update()
    {
        //gameObjectToMove.transform.position = new Vector3(x,y,z);
        //float horizontalInput = Input.GetAxis("Horizontal");

        //transform.position = transform.position + new Vector3
        //(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);


        //transform.position = Vector3.Lerp(pos2, pos1, Mathf.PingPong(Time.time * movementSpeed, 1.0f));
        //transform.position = Vector3.Lerp(pos2, pos1, Mathf.Clamp(movementSpeed, posx2, posx1));
        transform.position = Vector3.MoveTowards (transform.position, target, movementSpeed * Time.deltaTime);

    }
}
