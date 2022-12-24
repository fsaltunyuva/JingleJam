using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
     public float amplitude;          //Set in Inspector 
     public float speed;              //Set in Inspector 
     private float tempVal;
     private float tempVal2;
     private Vector2 tempPos;
     
    //sfknsflksdalkfnlsdaks

     void Start () 
     {
         tempVal = transform.position.y; //Hediyenin y eksenindeki anlık değerini tutan değer
         tempVal2 = transform.position.x; //Hediyenin x eksenindeki anlık değerini tutan değer
     }
 
     void Update () 
     {   
        tempPos.x = tempVal2; //x ekseninde değişiklik yapılmaması için tekrar aynı değer giriliyor    
         tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time); //Sinüs grafiğini kullanarak hediyeyi y ekseninde yukarı aşağı oynatan satır
         transform.position = tempPos; 
     }
}
