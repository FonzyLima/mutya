using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public SoundCollide soundCollide;
    public Image fillArea;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = soundCollide.currentHealth/soundCollide.maxHealth;
        slider.value = fillValue;
    }
}
