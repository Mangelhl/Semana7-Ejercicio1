using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextoStorage 
{
    public static List<List<string>> Situaciones = new List<List<string>>
    {
      new List<string>
        {
            "Texto de la primera situación: Estás frente a una puerta cerrada. ¿Qué quieres hacer?",
            "1. Intentar abrir la puerta.",
            "2. Buscar otra ruta.",
            "3. Trepar la puerta."
        },
      new List<string>
        {
            "Texto de la segunda situación: Encuentras una espada mágica en el suelo. ¿Qué quieres hacer?",
            "1. Tomar la espada.",
            "2. Ignorar la espada y continuar.",
            "3. Destruir la espada."
        },
      new List<string>
        {
            "Texto de la tercera situación: Te encuentras con un guardia poderoso. ¿Qué quieres hacer?",
            "1. Intentar luchar contra el guardia.",
            "2. Intentar persuadir al guardia.",
            "3. Buscar una ruta alternativa."
        },
    };
}
