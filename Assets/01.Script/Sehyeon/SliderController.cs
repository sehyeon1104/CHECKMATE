
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
  [SerializeField]  AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] string parameterName = "";
    public void TurnOffOnAudio()
    {

    }
    public void SoundControl()
    {
        float sound = volumeSlider.value;
        if (sound == -20) audioMixer.SetFloat(parameterName, -80);
        else audioMixer.SetFloat(parameterName, sound);
    }
}
