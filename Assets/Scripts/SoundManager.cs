using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    AudioSource _mainMenuSound;

    [Range(0, 1)]
    public float volumeAmount;

    private protected override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource[] allAudioSources = GetComponents<AudioSource>();
        _mainMenuSound = allAudioSources[0];

        foreach (AudioSource audioSource in allAudioSources) audioSource.volume = volumeAmount;
    }

    public void PlayMainMenuSound() => _mainMenuSound.Play();
    public void StopMainMenuSound() => _mainMenuSound.Stop();
}
