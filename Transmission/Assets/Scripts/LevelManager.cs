using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public GameObject optionsCanvas;
    public GameObject mainCanvas;
    public Slider volumeSlider;

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
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
        Debug.Log("Game quit requested");
        Application.Quit();
	}
}
