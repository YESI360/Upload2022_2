using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarBody : MonoBehaviour
{
    Renderer rend;
    public float currentValue;
    private float TransparencyLevel;
    public float speed;

    void Start()
    {
        currentValue = 0;
        rend = GetComponent<Renderer>();
        prender();
        currentValue = rend.material.GetFloat("_Alpha");
        
    }

    public void apagar()
    {
        rend.enabled = false;
    }

    public void prender()
    {
        rend.enabled = true;
        currentValue = rend.material.GetFloat("_Alpha");
        TransparencyLevel += Time.deltaTime * speed;
        rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
    }

    public void trans()
    {
        rend.material.SetFloat("_Alpha", currentValue);
    }
    void Update()
    {
        if (Input.GetKey("m"))//(Input.GetMouseButtonDown(0))
        {
            Debug.Log("apagar");
            apagar();
        }

        if (Input.GetKey("n"))//(Input.GetMouseButtonDown(0))
        {
            Debug.Log("prender");
            prender();
        }
    }
}
