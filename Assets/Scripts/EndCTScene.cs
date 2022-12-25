using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCTScene : MonoBehaviour
{
    private float time = 33f;

    private float prf;
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
