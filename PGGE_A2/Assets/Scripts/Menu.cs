using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OnClickSinglePlayer()
    {
        //Debug.Log("Loading singleplayer game");
        SceneManager.LoadScene("SinglePlayer");
    }

    public void OnClickMultiPlayer()
    {
        //Debug.Log("Loading multiplayer game");
        SceneManager.LoadScene("Multiplayer_Launcher");
    }

}
