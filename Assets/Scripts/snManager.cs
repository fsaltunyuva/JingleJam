using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snManager : MonoBehaviour
{

    private float prf=0f;
    public void Play()
    {
        if (prf == 3)
        {
            SceneManager.LoadScene(2);
        }
        else if (prf == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Quitt()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        prf = PlayerPrefs.GetFloat("SC");
        print(prf);
    }

}
