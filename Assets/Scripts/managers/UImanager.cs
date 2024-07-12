using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    //public GameObject panel_paused;
    [SerializeField]
    public AudioMixer game_audio_mixer;
    public Slider game_audio_slider;

    //public void pauseGame() 
    //{
    //    if (panel_paused.activeSelf == false)
    //    {

    //        panel_paused.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //}
    
    //public void resumeGame() 
    //{ 
    //    if(panel_paused.activeSelf == true) 
    //    {

    //        panel_paused.SetActive(false);
    //        Time.timeScale = 1f;
    //    }
    //}


    public void setMusicValue() 
    {
        float volume = game_audio_slider.value;
        game_audio_mixer.SetFloat("music", Mathf.Log10(volume) * 20);
    
    }

    public void setSoundValue() 
    {
        float volume = game_audio_slider.value;
        game_audio_mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);

    }
    
}
