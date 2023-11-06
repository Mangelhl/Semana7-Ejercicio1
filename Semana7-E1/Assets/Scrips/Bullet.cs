using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CustomGameObject
{
    public Vector3 Direction { get; set; }
    public int Damage { get; set; }
        
    public override void Update()
    {
        this.Position += this.Direction * this.Velocity * Time.deltaTime;

        Collider[] hitColliders = Physics.OverlapBox(this.Position, new Vector3(1.0f, 1.0f, 1.0f));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(this.Damage);
                    Destroy();
                }
            }
            else if (hitCollider.gameObject.CompareTag("Enemy2"))
            {
                Enemy2 enemy2 = hitCollider.gameObject.GetComponent<Enemy2>();
                if (enemy2 != null)
                {
                    enemy2.TakeDamage(this.Damage);
                    Destroy();
                }
            }
        }
    }
}
