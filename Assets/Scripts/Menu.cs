using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

    public string map;
	public void StartGame()
    {
        SceneManager.LoadScene(map);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
