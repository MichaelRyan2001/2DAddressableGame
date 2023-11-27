using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Endgame3 : MonoBehaviour
{
    private bool clearPreviousScene = false;
    private SceneInstance previousLoadedScene;
    //public Object sceneToLoad;
    public string addressableKey;

    private void Update()
    {
        var enemies = GameObject.FindWithTag("Enemy");

        if (enemies == null)
        {
            //SceneManager.LoadSceneAsync(sceneToLoad.name);
            LoadAddressableLevel(addressableKey);
            Debug.Log("There are no more enemies in the scene");
            Destroy(GameObject.Find("SceneManager3"));
            Destroy(GameObject.Find("idle_player_basic3"));
        }

    }

    public void LoadAddressableLevel(string addressableKey)
    {
        if (clearPreviousScene)
        {
            Addressables.UnloadSceneAsync(previousLoadedScene).Completed += (asyncHandle) =>
            {
                clearPreviousScene = false;
                previousLoadedScene = new SceneInstance();
                Debug.Log($"Unloaded scene {addressableKey} successfully");
            };
        }

        Addressables.LoadSceneAsync(addressableKey, LoadSceneMode.Additive).Completed += (asyncHandle) =>
        {
            clearPreviousScene = true;
            previousLoadedScene = asyncHandle.Result;
            Debug.Log($"Loaded scene {addressableKey} successfully");
        };
    }
}