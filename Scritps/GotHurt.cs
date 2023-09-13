using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotHurt : MonoBehaviour
{
    //red Image
    public GameObject redImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dimRed();
    }
    //red screen when getting hit
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            gotHurt();
        }
    }
    
    private void gotHurt()
    {
        //wenn man mit einem zombie kollidiert wird der bildschirm rot
        var color = redImage.GetComponent<Image>().color;
        color.a = 0.8f;
        redImage.GetComponent<Image>().color = color;
    }
    private void dimRed()
    {
        //der bildschirm wird wieder normal
        if (redImage.GetComponent<Image>().color.a > 0)
        {
            var color = redImage.GetComponent<Image>().color;
            color.a -= 0.01f;
            redImage.GetComponent<Image>().color = color;
        }
    }
    
}
