using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 7.0f;
    private float horizontalSpeed = 12.0f;
    //Barrier, (Player can't walk further)
    private float xRange = 40.0f;
    private float zRange = 40.0f;
    //private float verticalSpeed = 2.0f;
    //springen
    private Vector3 jump;
    private float jumpForce = 2.0f;
    
    private float jumpDelay = 0.7f;
    private float nextJump;
    // Start is called before the first frame update
    // ob spieler am boden ist
    public bool isGrounded;
    Rigidbody rb;
    //for the shooting mechanic
    public GameObject bulletPrefab;
    private float fireRate = 0.3f;
    private float nextShot;
    //leben des Spielers
    private float leben = 5;
    public float currentLevel;
    public static bool isDead;
    //anzeige für leben
    public TMP_Text lebenText;
    //public bool mausGedrückt; <-- nur zum testen
    
    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Turn();
        ShootBullet();
        if(Highscore.lastLevel > 3)
        {
            OutOfBoundsNew();
        }
        else
        {
            OutOfBounds();
        }
        
        //nur zum testen
        //CheckMouse();
    }
    private void PlayerMovement()
    {
        // Input Manager wandelt "a" und "d" als Tastenschlag in -1 und 1 um, das selbe funktioniert bei vor und zurück bewegen
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        Jump();
    }
    //springen
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded&& Time.time> nextJump)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            nextJump = Time.time + jumpDelay;
        }
    }
    
    // wenn spieler boden berührt wird is grounded auf true gesetzt
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    //spieler mit maus drehen
    private void Turn()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
        /*
         float h = horizontalSpeed * Input.GetAxis("Mouse X");
         float v = verticalSpeed * Input.GetAxis("Mouse Y");
         transform.Rotate(v, h, 0);
         wenn man einen kopf hat, der sich seperat drehen kann, dann kann man auch hoch und runter schauen, ist nicht möglich das komplette objekt zu drehen
         */
    }
    private void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.time>nextShot)
        {
            Vector3 offset = new Vector3(0, 0.5f, 0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            nextShot = Time.time + fireRate;
        }
    }
    //if the player goes further than the border he will be set back to the x or z position of the border
    private void OutOfBounds()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
    private void OutOfBoundsNew()
    {
        if (transform.position.x < -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 100)
        {
            transform.position = new Vector3(100, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }
        if (transform.position.z > 100)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100);
        }
    }
    // if the player collides with an object this method is called
    private void OnCollisionEnter(Collision other)
    {
        //if the collider's name tag is enemy
        if (other.gameObject.tag == "enemy")
        {
            //-1 leben wenn man mit einem object, mit dem tag enemy collidet
            leben = leben - 1;
            lebenText.text = "Leben: " + leben;
            Destroy(other.gameObject);
            if (leben <= 0)
            {
                //man stirbt, wenn man kein leben mehr hat
                Destroy(gameObject);
                isDead = true;
                SceneManager.LoadScene("Death Scene");
            }
        }
    }
     /*
    private void CheckMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mausGedrückt = true;
        }
        else
        {
            mausGedrückt = false;
        }
    }
    */
}
