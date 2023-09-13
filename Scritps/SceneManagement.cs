using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //diese Methoden können beim Klicken von Knöpfen aufgerufen werden
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        ZombieMovement.score = 0;
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
        ZombieMovement.score = 0;
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
        ZombieMovement.score = 0;
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
        ZombieMovement.score = 0;
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
        ZombieMovement.score = 0;
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level 6");
        ZombieMovement.score = 0;
    }
    public void LoadStartUI()
    {
        SceneManager.LoadScene("Start UI");
    }
    public void LoadStartLevel1()
    {
        SceneManager.LoadScene("Start Level 1");
        ZombieMovement.score = 0;
    }

    public void LoadStartLevel2()
    {
        SceneManager.LoadScene("Start Level 2");
        ZombieMovement.score = 0;
    }
    public void LoadStartLevel3()
    {
        SceneManager.LoadScene("Start Level 3");
        ZombieMovement.score = 0;
    }
    public void LoadStartLevel4()
    {
        SceneManager.LoadScene("Start Level 4");
        ZombieMovement.score = 0;
    }

    public void LoadStartLevel5()
    {
        SceneManager.LoadScene("Start Level 5");
        ZombieMovement.score = 0;
    }
    public void LoadStartLevel6()
    {
        SceneManager.LoadScene("Start Level 6");
        ZombieMovement.score = 0;
    }
    public void Pre()
    {
        SceneManager.LoadScene("Pre-Levelselection");
    }
}
