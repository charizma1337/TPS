using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float value = 100;
    public RectTransform valueRectTransform;

    public GameObject GamePlayUI;
    public GameObject GameOverScreen;

    private float _maxValue;


    private void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0 ) 
        {
            GamePlayUI.SetActive(false);
            GameOverScreen.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            GetComponent<FireBallCaster>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
        }

        DrawHealthBar();

    }


    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }

}
