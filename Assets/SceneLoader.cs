using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName = "";
    [SerializeField] private Slider slider = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame() {
        StartCoroutine(LoadGameAsync(sceneName));
    }
    private IEnumerator LoadGameAsync(string sceneName) {
        //SceneManager.LoadScene(sceneName);
        //yield return null;
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);
        sceneLoad.allowSceneActivation = false;
        while(sceneLoad.progress < 0.9f) {
            yield return null;
        }
        slider.value = 1.0f;
        yield return null;
        sceneLoad.allowSceneActivation = true;
    }
}
