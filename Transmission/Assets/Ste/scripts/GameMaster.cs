using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Slider timeSlider;
    public int playerTime;
    public float startCountDownAfter = 2f;
    public float decreaseSpeed = 0.1f;
    [Space]
    public GameObject effect;
    public GameObject signal;
    public static GameObject objEffect, objSignal;

    public static GameMaster instance;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        #endregion

        objEffect = effect;
        objSignal = signal;

        timeSlider.maxValue = playerTime;
        timeSlider.value = playerTime;
        InvokeRepeating("DecreaseTime", startCountDownAfter, decreaseSpeed);
    }

    void DecreaseTime()
    {
        timeSlider.value -= 1;

        if (timeSlider.value <= 0)
        {
            CancelInvoke();
            PlayerController.gameOver = true;
            print("Game Over");
        }
    }

    public void RechargeBar(int value = 0)
    {
        if (value == 0)
            timeSlider.value = timeSlider.maxValue;
        else
            timeSlider.value += value;

    }
}
