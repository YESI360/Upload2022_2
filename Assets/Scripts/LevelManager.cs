using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float transitionTime = 1f;
    public ActivarBody body;

    void Update()
    {
        if (Input.GetKey("space"))//(Input.GetMouseButtonDown(0))
        {
            Debug.Log("next");
            LoadNextLevel();
            body.apagar ();//para que en las siguentes escenas NO SE VEA EL AVATAR
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
