using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameCharacter : MonoBehaviour
{
    public string Name { get; set; }
    public int Force { get; set; }
    public int Skill { get; set; }
    public int Life { get; set; }

    public abstract void CreateCharacter(int force, int skill, int life);
}
