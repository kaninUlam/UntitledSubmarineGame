using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonForWinOrLose : MonoBehaviour
{

    
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }


    // Need to remove this from being a comment when the main menu is done.
    /*public void MainMenu()
    {
        SceneManager.LoadScene();
    }*/
}
