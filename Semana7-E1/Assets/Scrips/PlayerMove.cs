using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : GameObject
{
    public Vector2 Direction { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }

    public void Shoot()
    {
        Bullet bullet = new Bullet();
        bullet.Direction = this.Direction;
       
    }

    public void UpdateMovement(Vector2 newDirection)
    {
        
        this.Direction = newDirection;

        this.Position += this.Direction * this.Velocity;
    }

}
 