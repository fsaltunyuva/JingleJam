using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSC : MonoBehaviour
{
    public Sprite[] sprites;
    public int spt_value;
    public GameObject img;
    public GameObject cuce; //Cüceyi silmek için
    public bool isDialogueOver = false; //Diyalog sırasında inputu engellemek için

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (spt_value == 18)
            {
                Destroy(img);
                Destroy(cuce);
                bool isDialogueOver = true;
            }
            if (spt_value < 18)
            {
                spt_value += 1;
                this.gameObject.GetComponent<Image>().sprite = sprites[spt_value];
            }
        }
    }
}
