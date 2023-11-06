using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CustomGameObject : MonoBehaviour
{
    public Vector3 Position { get; set; }
    public float Velocity { get; set; }
    public void Destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
    public abstract void Update();
}