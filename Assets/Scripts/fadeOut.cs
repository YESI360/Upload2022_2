using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class fadeOut : MonoBehaviour
{
        private void Update()
        {
            if (Input.GetKey("space"))
        {
            SteamVR_LoadLevel.Begin("0222CalibrationBLACK-shader");
            }
        }

 }
