using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume {  get; private set; }
    public static float soundEffectsVolume { get; private set; }

    [SerializeField] private Text musicSliderText;
    [SerializeField] private Text soundEffectsSliderText;

    private void Start()
    {
        OnMusicSliderValueChange(0.0001f);
        OnSoundEffectSliderValueChange(0.0001f);
    }

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;

        musicSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();

    }

    public void OnSoundEffectSliderValueChange(float value)
    {
        soundEffectsVolume = value;

        soundEffectsSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.instance.UpdateMixerVolume();

    }

}
