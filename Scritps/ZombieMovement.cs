using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private float speed = 2.0f;
    private float movementSpeed = 3.5f;
    public GameObject Player; 
    //score
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Movement();
    }
    void Rotation()
    {
        //setzt die Position relativ zum Objekt, wo das Objekt hinschauen soll
        var lookPos = Player.transform.position - transform.position;
        lookPos.y = 0;
        //macht aus Vector3 Quaternion, um es unten verwenden zu k�nnen
        var rotation = Quaternion.LookRotation(lookPos);
        // dreht das objekt zum spieler
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
    void Movement()
    {
        // l�sst das objet vorw�rts laufen,
        // "Time.deltaTime" um es langsamer zu machen und die Geschwindigkeit besser kontrollieren zu k�nnen + Geschwindigkeit w�re sonst von Frame abh�ngig und so ist sie von der Zeit abh�ngig
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Destroys object when they collide
        Destroy(gameObject);
        Destroy(other.gameObject);
        //+1 score, wenn die Kugel einen Zombie trifft
        score++;
    }
}


