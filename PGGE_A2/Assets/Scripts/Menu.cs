using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource ClickSound;
    public void OnClickSinglePlayer()
    {   
        //play audio on click
        ClickSound.Play();
        //Debug.Log("Loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer");
        
    }

    public void OnClickMultiPlayer()
    {
        //play audio on click
        ClickSound.Play();
        //Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
        
    }

}
