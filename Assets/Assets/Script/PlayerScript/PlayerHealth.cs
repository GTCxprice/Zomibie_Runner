using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    private Slider health_Slider;
    private GameObject UI_Holder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health_Slider = GameObject.Find("Health bar").GetComponent<Slider>();

        health_Slider.value = health;
        UI_Holder = GameObject.Find("UI Holder");
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        health_Slider.value = health;

        if (health == 0)
        {
            UI_Holder.SetActive(false);
            GamePlayController.instance.GameOver();
        }

    }
}
