using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Border in x and z direction, so the bullet gets destroyed and doesn't fly forever
    private float xBound = 55.0f;
    private float zBound = 55.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Highscore.lastLevel>3)
        {
            DestroyGameObjectsNew();
        }
        else
        {
            DestroyGameObjects();
        }
        
    }
    void DestroyGameObjects()
    {
        if (transform.position.z > zBound)
        //destroys gameObject, when too high
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zBound)
        //destroys gameObject, when too low
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -xBound)
        {
            //destroys game object, when to far in any x-direction
            Destroy(gameObject);
        }
        else if (transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
    }
    void DestroyGameObjectsNew()
    {
        if (transform.position.z > 110)
        //destroys gameObject, when too high
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -15)
        //destroys gameObject, when too low
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -15)
        {
            //destroys game object, when to far in any x-direction
            Destroy(gameObject);
        }
        else if (transform.position.x > 120)
        {
            Destroy(gameObject);
        }
    }
}
