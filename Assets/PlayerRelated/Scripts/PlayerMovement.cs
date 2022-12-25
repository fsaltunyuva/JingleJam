using System.Collections;
using System.Collections.Generic;
using System; //try-catch için
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f; 
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Vector2 moveInput;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    Vector2 startScale;
    Vector2 startPosition;
    
    public GameObject image;

    void Start()
    {
        image = GameObject.FindGameObjectWithTag("Image"); //Diyalogun bitip bitmediğini kontrol etmek için
        startPosition = transform.position; //Aşağı düştükten sonra başlangıç pozisyonuna geri döndürebilmek için
        myRigidbody = GetComponent<Rigidbody2D>(); 
        myAnimator = GetComponent<Animator>();   
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>(); //Yerle olan etkileşimin kontrolü için 
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void Run() 
    {
        
        //
        try{
            if(image.GetComponent<ImageSC>().isDialogueOver == false){ //Diyalog bitmeden input almayı engelleme 
                myRigidbody.velocity = new Vector2(0f,0f);
                GetComponent<AudioSource>().Pause();
                return;
            }
        }
        catch(Exception e){}
        //     

        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y); //x ekseninde "verilen input*koşma hızı"nda, y ekseninde ise oyuncunun halihazırdaki y eksenindeki hızı  
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; //oyuncunun yatayda hızı olup olmadığını dönen boolean (42. satırda animasyon oynatımı için kullanılıyor.)
        GetComponent<AudioSource>().UnPause(); 
        if(!playerHasHorizontalSpeed || !myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            GetComponent<AudioSource>().Pause();
        }
            
        
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed); //Kullanıcının yatayda hızı olduğu sürece "isRunning" adlı animasyon boolean'ini true ya da false yapan satır

    }

    void FlipSprite() //Sağ ve sol inputlarına göre karakterin baktığı yönü değiştiren metod
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon; //Run metodundaki boolean ile aynı işlevde

        if (playerHasHorizontalSpeed){
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f); //Oyuncu gameObjectinin x eksenindeki scale'ini kullanıcının hızının işaretini alarak belirleyen satır (- yönde hızı varsa, yönü sola dönüyor)
        }
    }

    void OnJump(InputValue value) {
        
        //
        try{
            if(image.GetComponent<ImageSC>().isDialogueOver == false){ //Diyalog bitmeden input almayı engelleme
                myRigidbody.velocity = new Vector2(0f,0f);
                return;
            }
            }
        catch(Exception e){}
        //

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {return;} //Sonsuz kere zıplamayı engellemek için kullanıcının ayağı yere değmediği sürece zıplamayı engelleyen satır

        if (value.isPressed && !myAnimator.GetBool("isJumping")) {
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed); //Zıplama vektörünün tanımlandığı satır
            myAnimator.SetBool("isJumping", true); //Zıplama işleminin ardından animator'deki isJumping booleanini true yapan satır
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Oyuncu yere indiğinde zıplama animasyonunu durduran ve aşağı düşmeyi kontrol eden metod
        {
            if(other.tag == "Death Triggerer") { //Aşağı düştükten sonra başlangıç pozisyonuna geri döndürebilmek için
                transform.position = startPosition;
            }

            myAnimator.SetBool("isJumping", false);
        }
    
    
}
