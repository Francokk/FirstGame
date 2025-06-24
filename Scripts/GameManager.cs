using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshProUGUI texto;

    void Start()
    {
        
    }

    void Update()
    {
        texto.text = "Score: " + Score.ToString(); // Actualiza el texto en pantalla
    }
}
