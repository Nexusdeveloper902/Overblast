using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
