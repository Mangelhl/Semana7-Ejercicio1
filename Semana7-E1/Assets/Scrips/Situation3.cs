using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Situation3 : MonoBehaviour, ITextDisplay
{    
    public int ForceRequired { get; set; } = 10;
    public int RequiredSkill { get; set; } = 20;
    void Start()
    {
        string textoSituacion1 = TextoStorage.Situaciones[3][0];
        string opcion2Situacion2 = TextoStorage.Situaciones[3][1];
    }
    public void ShowText()
    {
        List<string> situacion = TextoStorage.Situaciones[3];
        for (int i = 0; i < situacion.Count; i++)
        {
            Debug.Log(situacion[i]);
        }
    }
}
