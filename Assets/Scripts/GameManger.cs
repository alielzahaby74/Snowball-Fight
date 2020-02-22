using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManger : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;

    public int p1Life;
    public int p2Life;

    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public string mainMenu;

    public AudioSource hurtSound;
	void Start () {
		
	}
	
	void Update ()
    {
		if(p1Life <= 0)
        {
            player1.SetActive(false);
            p2Wins.SetActive(true);
        }
        if (p2Life <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);
        }
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScreen");
        }
    }
    public void HurtP1()
    {
        p1Life -= 1;
        p1Sticks[p1Life].SetActive(false);
        hurtSound.Play();
    }
    public void HurtP2()
    {
        p2Life -= 1;
        p2Sticks[p2Life].SetActive(false);
        hurtSound.Play();
    }
}
