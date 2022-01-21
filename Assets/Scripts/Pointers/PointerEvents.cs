using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    //[SerializeField] private Color normalColor = Color.white;
    //[SerializeField] private Color enterColor = Color.white;
    //[SerializeField] private Color downColor = Color.white;
    //[SerializeField] private UnityEvent OnClick = new UnityEvent();
    public bool gaze;
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().enabled = true;
        //meshRenderer.material.color = enterColor;
        print("GAZE GUIA?");
        gaze = true;
        SoundManagerGuia.instance.PlayInstruccion04();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //GetComponent<MeshRenderer>().enabled = false;
        //meshRenderer.material.color = normalColor;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // meshRenderer.material.color = downColor;
        //print("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //meshRenderer.material.color = enterColor;
        //print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //OnClick.Invoke();
        //print("Click");
    }
}
