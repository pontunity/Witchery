using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuFunctions : MonoBehaviour
{
    // Adding the master bus so we can stop all sound on level restart.
    FMOD.Studio.Bus MasterBus;
    


    public bool Paused = false;

    public float masterVolume;

    [SerializeField]
    Slider volumeSlider;

    public float heightSliderValue;

    [SerializeField]
    Slider heightSlider;

    [SerializeField]
    GameObject headsetHeight;



    private void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/");
    }

    private void Update()
    {
      ChangeHeight();
      ChangeMasterVolume();


    }

    public void PauseGame()
    {
        Paused = !Paused;
        if (Paused == true)
        {
            Time.timeScale = 0;
            MasterBus.setPaused(true);
        }
        else
        {
            Time.timeScale = 1;
            MasterBus.setPaused(false);
        }
    }
    
    public void RestartLevel()
    {

        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMasterVolume()
    {
        masterVolume = volumeSlider.value;
        MasterBus.setVolume(masterVolume);
    }

    public void ChangeHeight()
    {
        heightSliderValue = heightSlider.value;
        Vector3 temp = transform.position;
        temp.y = heightSliderValue;
        
        headsetHeight.transform.position = transform.localPosition = temp;
    }

}
