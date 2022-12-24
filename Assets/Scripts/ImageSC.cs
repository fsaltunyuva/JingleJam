using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSC : MonoBehaviour
{
    public Sprite[] sprites;
    public int spt_value;
    public GameObject img;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (spt_value == 18)
            {
                Destroy(img);
            }
            if (spt_value < 18)
            {
                spt_value += 1;
                this.gameObject.GetComponent<Image>().sprite = sprites[spt_value];
            }
        }
    }
}
