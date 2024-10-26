using UnityEngine;
using UnityEngine.UI;

public class BackgroundApplier : MonoBehaviour
{
    [SerializeField] private Image _targetBackgroundImage;
    [SerializeField] private Sprite[] _availableBackgroundSprites;

    private const string BackgroundKey = "SelectedBackground";

    private void Start()
    {
        ApplySavedBackground();
    }

    /// <summary>
    /// Применяет сохраненный фон, если таковой имеется.
    /// </summary>
    private void ApplySavedBackground()
    {
        if (PlayerPrefs.HasKey(BackgroundKey))
        {
            int savedBackgroundIndex = PlayerPrefs.GetInt(BackgroundKey);
            _targetBackgroundImage.sprite = _availableBackgroundSprites[savedBackgroundIndex];
        }
    }
}