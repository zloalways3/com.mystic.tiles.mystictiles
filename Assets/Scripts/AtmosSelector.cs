using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AtmosSelector : MonoBehaviour
{
    [SerializeField] private Image previewImage;  // Image для отображения превью
    [SerializeField] private Image backgroundImage;  // Image для установки заднего фона на сцене
    [SerializeField] private Sprite[] previewOptions;  // Массив для картинок превью
    [SerializeField] private Sprite[] backgroundOptions;  // Массив для задних фонов
    [SerializeField] private Button nextButton;  // Кнопка "Next" для пролистывания вперед
    [SerializeField] private Button prevButton;  // Кнопка "Previous" для пролистывания назад
    [FormerlySerializedAs("saveButton")] [SerializeField] private Button gameSaveButton;  // Кнопка "Save" для подтверждения выбора

    private int currentBackgroundIndex = 0;  // Индекс текущего фона

    void Start()
    {
        // Загружаем последний сохраненный фон, если он есть
        if (PlayerPrefs.HasKey("SelectedBackground"))
        {
            currentBackgroundIndex = PlayerPrefs.GetInt("SelectedBackground");
        }

        RevisePreviewPane();  // Обновляем отображение превью

        // Привязываем методы к кнопкам
        nextButton.onClick.AddListener(BackdropAdvance);
        prevButton.onClick.AddListener(BackdropRetro);
        gameSaveButton.onClick.AddListener(RetainBackdrop);
    }

    // Метод для пролистывания фонов вперед
    private void BackdropAdvance()
    {
        currentBackgroundIndex = (currentBackgroundIndex + 1) % previewOptions.Length;
        RevisePreviewPane();
    }

    // Метод для пролистывания фонов назад
    private void BackdropRetro()
    {
        currentBackgroundIndex = (currentBackgroundIndex - 1 + previewOptions.Length) % previewOptions.Length;
        RevisePreviewPane();
    }

    // Обновляем previewImage для отображения выбранного превью
    private void RevisePreviewPane()
    {
        previewImage.sprite = previewOptions[currentBackgroundIndex];
    }

    // Сохраняем выбранный фон и обновляем фон на сцене
    private void RetainBackdrop()
    {
        PlayerPrefs.SetInt("SelectedBackground", currentBackgroundIndex);
        PlayerPrefs.Save();

        // Применяем соответствующее изображение из массива backgroundOptions как задний фон
        backgroundImage.sprite = backgroundOptions[currentBackgroundIndex];
    }
}
