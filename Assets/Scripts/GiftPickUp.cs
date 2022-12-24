using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftPickUp : MonoBehaviour
{
    [SerializeField] int pointsForGiftPickup = 1; //Her hediyenin skora kaç ekleyeceğini belirten satır

    bool wasCollected = false; //Hediyenin toplanıp toplanmadığını tutan boolean

    void OnTriggerEnter2D(Collider2D other) {//Game Session classındaki addToScore metodunu çağırarak UI'daki skoru arttıran metod

    if(!wasCollected) { 
        wasCollected = true;
        FindObjectOfType<GameSession>().AddToScore(pointsForGiftPickup);             
        Destroy(gameObject);
    }

}
}
