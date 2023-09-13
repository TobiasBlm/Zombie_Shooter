using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    private float flyingSpeed = 30.0f;
    //sonst würde der Bullet sich schon im Spieler selbst zerstören
    private float firstDelay = 0.05f;
    private float activationTime;
    // Start is called before the first frame update
    void Start()
    {
        activationTime = Time.deltaTime + firstDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // lässt das objet vorwärts laufen,
        // "Time.deltaTime" um es langsamer zu machen und die Geschwindigkeit besser kontrollieren zu können + Geschwindigkeit wäre sonst von Frame abhängig und so ist sie von der Zeit abhängig
        transform.Translate(Vector3.forward * flyingSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Time.deltaTime > activationTime)
        {
            //Destroys object when they collide
            Destroy(gameObject);
        }
    }
}
