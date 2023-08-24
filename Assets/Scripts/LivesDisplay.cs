using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth health;

   
    private void Update()
    {
       slider.value = health.GetHealth();
    }

}
