using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class AddressablesManager : MonoBehaviour
{
    private bool clearPreviousScene = false;
    private SceneInstance previousLoadedScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
