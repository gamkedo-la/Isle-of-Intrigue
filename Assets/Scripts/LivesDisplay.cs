using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    public PlayerHealth health;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMeshPro.text = health.GetLives().ToString();
    }

}
