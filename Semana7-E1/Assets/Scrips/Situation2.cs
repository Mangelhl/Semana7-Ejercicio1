using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation2 : MonoBehaviour, ITextDisplay
{    
    public int ForceRequired { get; set; } = 15;
    public int RequiredSkill { get; set; } = 5;

    void Start()
    {
        string textoSituacion1 = TextoStorage.Situaciones[2][0];
        string opcion2Situacion2 = TextoStorage.Situaciones[2][1];
    }

    public void ShowText()
    {
        List<string> situacion = TextoStorage.Situaciones[2];
        for (int i = 0; i < situacion.Count; i++)
        {
            Debug.Log(situacion[i]);
        }
    }
}
