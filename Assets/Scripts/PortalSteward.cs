using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSteward : MonoBehaviour
{
    /// <summary>
    /// Загружает сцену, указанную для перехода в Limbo.
    /// </summary>
    public void LoadLimboRealm()
    {
        LoadSceneByName(AvatarPhaseSetup.PixelAdventure);
    }

    /// <summary>
    /// Загружает сцену, указанную для перехода в Voxel Odyssey.
    /// </summary>
    public void LoadVoxelOdysseyRealm()
    {
        LoadSceneByName(AvatarPhaseSetup.InterimDomain);
    }

    /// <summary>
    /// Выполняет загрузку сцены по имени.
    /// </summary>
    /// <param name="sceneName">Имя сцены, которую нужно загрузить.</param>
    private void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}