﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabelsFOR : MonoBehaviour
{
    public MyMessageListener datos;
    //public SensorManagerB datos;
    //public MyMessageListenerSHARED datos;


    private void OnGUI()
    {
        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(5, 5, 100, 600), "Belly " + datos.datoL);//calibracionCB
        GUI.Label(new Rect(5, 30, 100, 600), "Chest " + datos.datoL2);//calibracionCC


        //GUILayout.Label("<size=30> <color=yellow>CHEST</color> + datoL2</size>", style);

        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        //GUILayout.Label("<size=30>hola <color=yellow>HOLA</color> chau</size>", style);
    }
}