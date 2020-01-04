using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadCharacterScene ()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadIdleTrainingScene ()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit ()
    {
        Application.Quit();
    }


}
