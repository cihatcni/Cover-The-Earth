using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{

    AudioSource audioSource;
    AudioSource earthAudioSource;
    public Sprite soundOn;
    public Sprite soundOff;

    void Start()
    {
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();
        earthAudioSource = GameObject.Find("Earth").GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("volume") == 0)
            turnOffSound();  
    }

    void turnOnSound() {
        audioSource.volume = 1;
        earthAudioSource.volume = 1;
        GetComponent<Button>().GetComponent<Image>().sprite = soundOn;
        PlayerPrefs.SetInt("volume", 1);
    }

    void turnOffSound() {
        audioSource.volume = 0;
        earthAudioSource.volume = 0;
        GetComponent<Button>().GetComponent<Image>().sprite = soundOff;
        PlayerPrefs.SetInt("volume", 0);
    }

    public void soundClicked() {

        if (audioSource.volume == 0)
            turnOnSound();
        else
            turnOffSound();

    }


}
