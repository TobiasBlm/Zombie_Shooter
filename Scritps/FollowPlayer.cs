using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public float verticalSpeed = 2.0f;
    public float horizontalSpeed = 2.0f;
    public float playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        FollowP();
        Turn();
    }
    private void FollowP()
    {
        //folgt dem spieler mit einer verschiebung um höher zu sein
        Vector3 offset = new Vector3(0, 0.5f, 0);
        transform.position = Player.transform.position + offset;
    }
    private void Turn()
    {
        transform.rotation = Player.transform.rotation;
    }
}
