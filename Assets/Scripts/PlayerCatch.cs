using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCatch : MonoBehaviour
{
    public GameObject enemy;
    public GameObject pickup;


    public GameObject inimigo_apareceu;

    public GameObject enemy_1;
    public GameObject enemy_left;
    public GameObject enemy_right;



    private float tempo;

    
    private int count;
    private int count_left;
    private int count_right;



    void Start()
    {
        tempo = 0.0f;
        count  = 0;
        SetCountText();
        inimigo_apareceu.SetActive(false);
        pickup.SetActive(false);
    }


    void setTextInimigo(){
        inimigo_apareceu.SetActive(true);
        count  = 0;
        tempo = 0.0f;
    }

   void SetCountText() 
   {
       if(count == 15){
            setTextInimigo();
            enemy_1.SetActive(true);-
       }
        if(count_left == 15){
            setTextInimigo();
            enemy_left.SetActive(true);
       }
        if(count_right == 15){
            setTextInimigo();
            enemy_right.SetActive(true);
       }


   }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count++;
        }
        if(other.gameObject.CompareTag("pickup_left")){
            other.gameObject.SetActive(false);
            count_left++;
        }
        if(other.gameObject.CompareTag("Pickup_right")){
            other.gameObject.SetActive(false);
            count_right++;
        }
        if(other.gameObject.CompareTag("chave")){
            other.gameObject.SetActive(false);
            enemy.SetActive(true);
            pickup.SetActive(true);
            setTextInimigo();

        }
    }

    // Update is called once per frame
    void Update()
    {
    
        if(tempo > 3){
            inimigo_apareceu.SetActive(false);
        }
        tempo += Time.deltaTime;  

        if(count + count_left + count_right == 45){
            SceneManager.LoadScene("Fim");
        }
    }
}
