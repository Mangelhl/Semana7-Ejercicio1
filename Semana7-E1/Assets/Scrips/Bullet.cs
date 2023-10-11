using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction { get; set; }
    public int Damage { get; set; }

    public Bullet(Vector2 direction, int damage)
    {
        this.Direction = direction;
        this.Damage = damage;
    }

    public override void Update()
    {
        
        this.Position += this.Direction * this.Velocity;

        
    }
}
