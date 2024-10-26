using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundwaveConductor : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioBlender;
    [SerializeField] private Slider _soundscapeSlider; // Слайдер для Soundscape
    [SerializeField] private Slider _melodySlider;     // Слайдер для Melody
    private const string SoundscapeVolumeKey = "SoundscapeVolume";
    private const string MelodyVolumeKey = "MelodyVolume";

    private void Start()
    {
        // Загрузка сохранённых уровней громкости
        float savedSoundscapeVolume = PlayerPrefs.GetFloat(SoundscapeVolumeKey, 0.8f);
        float savedMelodyVolume = PlayerPrefs.GetFloat(MelodyVolumeKey, 0.8f);

        _audioBlender.SetFloat(AvatarPhaseSetup.ReverbTrace, savedSoundscapeVolume);
        _audioBlender.SetFloat(AvatarPhaseSetup.AudioSignalPoint, savedMelodyVolume);

        // Установка значений слайдеров
        _soundscapeSlider.value = savedSoundscapeVolume;
        _melodySlider.value = savedMelodyVolume;
    }

    public void AmbientCurator(float volume)
    {
        _audioBlender.SetFloat(AvatarPhaseSetup.ReverbTrace, volume);
        PlayerPrefs.SetFloat(SoundscapeVolumeKey, volume); // Сохраняем значение громкости
    }

    public void HarmonySynth(float volume)
    {
        _audioBlender.SetFloat(AvatarPhaseSetup.AudioSignalPoint, volume);
        PlayerPrefs.SetFloat(MelodyVolumeKey, volume); // Сохраняем значение громкости
    }

    // Метод для сохранения настроек, привязанный к кнопке
    public void PreserveConfigurations()
    {
        PlayerPrefs.Save();
        Debug.Log("Настройки звука и позиции слайдеров сохранены.");
    }
}