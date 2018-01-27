using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    public GameObject optionsCanvas;
    public GameObject mainCanvas;
    public Slider volumeSlider; 

    public void OnStartPress()
	{
        Application.LoadLevel("MainScene");
	}

	public void OnOptionsPress()
	{
        optionsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
	}

    public void OnSliderUse()
    {
        AudioListener.volume = volumeSlider.value;
    }

	public void OnExitPress()
	{
        Application.Quit();
	}
}
