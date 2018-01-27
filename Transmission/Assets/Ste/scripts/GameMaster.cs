using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public Slider timeSlider;
    public int playerTime;
    public float startCountDownAfter = 2f;
    public float decreaseSpeed = 0.1f;

    public static GameMaster instance;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        #endregion

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
            PlayerController.state = PlayerController.State.GameOver;
            print("Game Over");
        }
    }

    public void RechargeBar()
    {
        timeSlider.value = timeSlider.maxValue;
    }
}
