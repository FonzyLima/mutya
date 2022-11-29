using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;
    [SerializeField] public AudioSource finalSFX;
    [SerializeField] public Color orange;
    [SerializeField] public Color red;

    public int Duration;
    
    private int remainingDuration;
    public bool Pause = false;

    private void Start()
    {
        Being(Duration);
    }

    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            if(!Pause)
            {
                if(remainingDuration == 30){
                    uiFill.color = orange;
                }
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                if(remainingDuration <= 10){
                    uiFill.color = red;
                    finalSFX.Play();
                }
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            finalSFX.Pause();
            yield return null;
        }
    }

    private void OnEnd()
    {
        print("End");
    }

    public void pauseTimer (bool val)
    {
        Pause = val;
    }
}
