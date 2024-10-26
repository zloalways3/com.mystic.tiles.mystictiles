using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrajectoryGuide : MonoBehaviour
{
    public static TrajectoryGuide appGlobalInstance;

    [SerializeField] private GameObject[] levelOptionButtons;
    [SerializeField] private Button chooseButton;

    private int _totalStagesCount = 60;
    private int _chosenLevelIndex = 1; // начальное значение -1, чтобы избежать проблем с выбором уровня

    void Start()
    {
        
        if (appGlobalInstance == null)
        {
            appGlobalInstance = this;
            DontDestroyOnLoad(gameObject);
        }

        ConfigurePlayfields();
        RefreshZoneSelectors();
        chooseButton.interactable = false;
    }

    private void ConfigurePlayfields()
    {
        for (int loopStepCounter = 0; loopStepCounter < _totalStagesCount; loopStepCounter++)
        {
            // Проверяем, есть ли уже сохраненные данные для уровня
            if (PlayerPrefs.GetInt(AvatarPhaseSetup.ProgressionPathway + loopStepCounter, -1) == -1)
            {
                // Открываем только первый уровень, остальные оставляем закрытыми
                if (loopStepCounter == 0)
                {
                    Debug.Log("Первый уровень открыт");
                    PlayerPrefs.SetInt(AvatarPhaseSetup.ProgressionPathway + loopStepCounter, 1); // Открытие первого уровня
                }
                else
                {
                    PlayerPrefs.SetInt(AvatarPhaseSetup.ProgressionPathway + loopStepCounter, 0); // Остальные уровни закрыты
                }
                
                PlayerPrefs.SetInt("StageCleared" + loopStepCounter, 0);
            }
        }
        PlayerPrefs.Save();
    }

    private void RefreshZoneSelectors()
    {
        for (int iterationCounter = 0; iterationCounter < _totalStagesCount; iterationCounter++)
        {
            if (levelOptionButtons[iterationCounter] != null)
            {
                // Уровень активен, если значение в PlayerPrefs равно 1
                bool isLevelUnlocked = PlayerPrefs.GetInt(AvatarPhaseSetup.ProgressionPathway + iterationCounter, 0) == 1;
                Button levelButton = levelOptionButtons[iterationCounter].GetComponent<Button>();
                levelButton.interactable = isLevelUnlocked; // Кнопка становится доступной только для открытых уровней
            }
        }
    }

    public void SelectEpoch(int levelIndex)
    {
        _chosenLevelIndex = levelIndex;
        chooseButton.interactable = true;
    }

    public void CommenceZone()
    {
        if (_chosenLevelIndex != -1)
        {
            PlayerPrefs.SetInt(AvatarPhaseSetup.PresentStage, _chosenLevelIndex);
            PlayerPrefs.Save();
            SceneManager.LoadScene(AvatarPhaseSetup.PixelAdventure);
        }
    }

    public void FulfillStageObjective(int levelIndex)
    {
        PlayerPrefs.SetInt("StageCleared" + levelIndex, 1); // Уровень пройден
        PlayerPrefs.Save();

        // Открываем следующий уровень, если он существует
        if (levelIndex < _totalStagesCount - 1)
        {
            PlayerPrefs.SetInt(AvatarPhaseSetup.ProgressionPathway + (levelIndex), 1); // Открываем следующий уровень
            PlayerPrefs.Save();
        }

        // Обновляем состояние кнопок уровней после завершения уровня
        RefreshZoneSelectors();
    }
}
