using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation1 : MonoBehaviour, ITextDisplay
{    
    public int ForceRequired { get; set; } = 20;
    public int RequiredSkill { get; set; } = 10;

    void Start()
    {
        string textoSituacion1 = TextoStorage.Situaciones[1][0];
        string opcion2Situacion2 = TextoStorage.Situaciones[1][1];
    }   

    public void ShowText()
    {
        List<string> situacion = TextoStorage.Situaciones[1];
        for (int i = 0; i < situacion.Count; i++)
        {
            Debug.Log(situacion[i]);
        }
    }
}
