using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class manosCintura : MonoBehaviour
{

    public GameObject handRed;//1
    public GameObject handBlue;//2

    public bool hands1 = true;
    public bool hands2 = true;
    public bool manoscintura;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.red;

    private MeshRenderer meshRenderer;

    private void Awake()//start?
    {
        meshRenderer = GetComponent<MeshRenderer>();//salvavidas
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Start()
    {
    }

    void Update() //BOTONERA
    {
        if (Input.GetKeyDown("x"))//DEBUG ver capsula
        {
            GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("salvavidasON");
        }
        if (Input.GetKeyDown("c"))//DEBUG dejar ver capsula
        {
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("salvavidasOFF");
        }
    }

    public void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag == "hands1")//handRed
        {
            hands1 = true;
            //Debug.Log("hands1");               
        }

        if (other.gameObject.tag == "hands2")//handBlue
        {
            hands2 = true;
            //Debug.Log("hands2");          
        }


        if (hands1 == true && hands2 == true)//////2 MANOS EN LA CINTURA 
        {
            hands2 = false;
            hands1 = false;
            Debug.Log("HANDRED+BLUE");
            manoscintura = true;
   
            ////////////////VER CAPSULA SOLO PARA DEBUG
            GetComponent<MeshRenderer>().enabled = true;
            meshRenderer.material.color = enterColor;//pinta SALVAVIDAS rojo
        }

    }

    private void OnTriggerExit(Collider other)///////SACO LAS MANOS
    {
        //meshRenderer.material.color = normalColor;//salvavidas CAMBIA COLOR AL SACAR MANOS
        GetComponent<MeshRenderer>().enabled = false;
        hands2 = true;
        hands1 = true;

        if (other.gameObject.tag == "hands1") hands1 = false;
        if (other.gameObject.tag == "hands2") hands2 = false;
    }

}
