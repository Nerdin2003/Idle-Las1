using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectsManager : MonoBehaviour
{
    public GameObject energizedEffect;  
    public bool isEnergized;

    public Button button;

    public float duration;

    private void Start()
    {
        button.onClick.AddListener(()=> {

            StartEnergizedEffect(duration);
        });
    
    } 

    public void StartEnergizedEffect(float duration)
    {
        isEnergized = true;
        energizedEffect.SetActive(true);
        energizedEffect.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().ActiveCountdown(duration);

        StartCoroutine(EndEnergizedEffect(duration));
    }

    IEnumerator EndEnergizedEffect(float delay)
    {
        yield return new WaitForSeconds (delay);
        isEnergized = false;
        energizedEffect.SetActive(false);
    }
}
