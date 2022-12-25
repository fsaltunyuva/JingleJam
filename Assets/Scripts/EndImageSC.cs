using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndImageSC : MonoBehaviour
{
    public Sprite[] spritesEnd;
    public int spt_valueEnd;
    public GameObject imgEnd;

    public void EndDialogues()
    {
        imgEnd.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (spt_valueEnd == 11)
            {
                SceneManager.LoadScene(3);
                Destroy(imgEnd);
            }
            if (spt_valueEnd < 11)
            {
                spt_valueEnd += 1;
                this.gameObject.GetComponent<Image>().sprite = spritesEnd[spt_valueEnd];
            }
        }
    }
}
