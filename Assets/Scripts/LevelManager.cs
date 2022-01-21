﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public Animator transition;
    public float transitionTime = 1f;
    public ActivarBody body;

    void Update()
    {
        if (Input.GetKey("space"))//(Input.GetMouseButtonDown(0))
        {
            Debug.Log("next");
            LoadNextLevel();
            body.apagar ();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
