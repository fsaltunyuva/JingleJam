using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    public float wait_time = 13f;

    void Start()
    {
        StartCoroutine(Wait_For_Outro());
        
    }

    IEnumerator Wait_For_Outro() 
    {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(0);
    }
}
