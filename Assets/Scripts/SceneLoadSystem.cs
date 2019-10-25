using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadSystem : MonoBehaviour
{
    public void BtnPlay() {
        SceneManager.LoadScene(2);
    }
    public void BtnExit() {
        Application.Quit();
    }
}
