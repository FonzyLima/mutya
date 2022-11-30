using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public SoundCollide soundCollide;
    public Image fillArea;
    public Text healthText;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Bakunawa ("+(soundCollide.currentHealth*10).ToString()+"/"+(soundCollide.maxHealth*10).ToString()+")";
        float fillValue = soundCollide.currentHealth/soundCollide.maxHealth;
        slider.value = fillValue;
    }
}
