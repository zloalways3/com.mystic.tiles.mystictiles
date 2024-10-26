using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealmTransitioner : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StreamStageAsync(AvatarPhaseSetup.PrimaryDimension));
    }

    /// <summary>
    /// Асинхронная загрузка сцены с задержкой до готовности к активации.
    /// </summary>
    /// <param name="sceneName">Название загружаемой сцены.</param>
    private IEnumerator StreamStageAsync(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
        loadOperation.allowSceneActivation = false;

        // Ждём, пока загрузка достигнет 90%, после чего активируем сцену
        while (!loadOperation.isDone)
        {
            if (loadOperation.progress >= 0.9f)
            {
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}