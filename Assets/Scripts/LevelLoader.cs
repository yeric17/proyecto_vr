using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : AutoCleanSingleton<LevelLoader>
{

    public Text percentageText;
    public Slider progressSlider;

    // public LevelLoader currInstance { get; private set; }

    public SceneList idxLoadScene = SceneList.Load;
    public bool isActiveLoadSene = false;
    public LevelLoader currInstace;

    private void Start()
    {
        currInstace = Instance;
    }
    public void Load(int sceneIndex)
    {
        if (!isActiveLoadSene)
        {
            PlayerPrefs.SetInt("NextScene", sceneIndex);
            SceneManager.LoadScene((int)idxLoadScene);
        }
        else
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            if (percentageText)
            {
                percentageText.text = progress * 100 + "%";
            }
            if (progressSlider)
            {
                progressSlider.value = progress;
            }

            yield return null;
        }
    }

}

public enum SceneList
{
    MainMenu,
    Load,
    TestLevel
}
