using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource ClickSound;
    public void OnClickSinglePlayer()
    {
        StartCoroutine(PlayClickSound("SinglePlayer"));
        //Debug.Log("Loading singleplayer game");
        //SceneManager.LoadScene("SinglePlayer");
        
    }

    public void OnClickMultiPlayer()
    {
        StartCoroutine(PlayClickSound("Multiplayer_Launcher"));
        //Debug.Log("Loading multiplayer game");
        //SceneManager.LoadScene("Multiplayer_Launcher");

    }
    // coroutine to play click sound
    IEnumerator PlayClickSound(string scene)
    {
       ClickSound.Play();
       yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
