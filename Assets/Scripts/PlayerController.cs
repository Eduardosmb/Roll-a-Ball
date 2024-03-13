using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private float movementZ;
    public float intensidade_pulo;

    public float speed = 0;
    private int count;

    public TextMeshProUGUI countText;

    public GameObject winText;

    private bool esta_no_ar = false;

    private float tempoAr = 0f;




    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0;

        SetCountText();
        winText.SetActive(false);
    }

    void Update(){
        if(esta_no_ar == true){
            tempoAr += Time.deltaTime;
            if(tempoAr >= 5){
                SceneManager.LoadScene("Morreu");
            }
        }
    }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if(count >= 15){
        winText.SetActive(true);
       }
   }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 

        movementX = movementVector.x;
        movementY =  movementVector.y;
        movementZ = 0.0f;
    }
    void OnJump(InputValue movementValue){
        if(esta_no_ar == false){
            rb.AddForce(Vector3.up * intensidade_pulo, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementZ, movementY);

        rb.AddForce(movement * speed);
        
    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            SceneManager.LoadScene("Morreu");
        }
        if(collision.gameObject.CompareTag("chao")){
            esta_no_ar = false;
            tempoAr = 0f;
        }
    }

    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("chao")){
            esta_no_ar = true;
        }
    }


}
