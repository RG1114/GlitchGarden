using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsController : MonoBehaviour
{
    
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume=0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty=5;
    void Start()
    {
        volumeSlider.value=playerPrefsController.GetMasterVolume();
        difficultySlider.value=playerPrefsController.GetMasterDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer=FindObjectOfType<musicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else{
            Debug.LogWarning("no music player found ");
        }
    }

    public void SaveAndExit(){
        playerPrefsController.SetMasterDifficulty((int)difficultySlider.value);
        playerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().MainMenuScene();
    }
    public void SetDefault(){
        volumeSlider.value=defaultVolume;
        difficultySlider.value=defaultDifficulty;
    }
}
