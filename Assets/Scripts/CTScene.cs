using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CTScene : MonoBehaviour
{
    private float time = 43f;

    private float prf;
    private void Update()
    {
        PlayerPrefs.SetFloat("SC", 3);
        prf = PlayerPrefs.GetFloat("SC");
        print(prf);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
