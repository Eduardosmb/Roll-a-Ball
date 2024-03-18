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

    private bool esta_no_ar = false;
    private float tempoAr = 0f;


    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
    }

    void Update(){
        if(esta_no_ar == true){
            tempoAr += Time.deltaTime;
            if(tempoAr >= 5){
                SceneManager.LoadScene("Morreu");
            }
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

    private void OnCollisionStay(Collision collision){
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
