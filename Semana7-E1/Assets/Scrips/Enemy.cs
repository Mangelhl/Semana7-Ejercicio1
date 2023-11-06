using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CustomGameObject
{
    public int Health { get; set; }
    public int Damage { get; set; }

    public void Initialize(int initialHealth, int initialDamage)
    {
        this.Health = initialHealth;
        this.Damage = initialDamage;
    }

    public Enemy(Vector3 initialPosition, int initialHealth, int initialDamage)
    {
        this.Position = initialPosition;
        this.Health = initialHealth;
        this.Damage = initialDamage;
    }

    public void TakeDamage(int damage)
    {
        this.Health -= damage;

        if (this.Health <= 0)
        {
            Destroy();
        }
    }

    public override void Update()
    {
        this.Position += new Vector3(this.Velocity, 0, 0) * Time.deltaTime;

        Collider[] hitColliders = Physics.OverlapBox(this.Position, new Vector3(1.0f, 1.0f, 1.0f));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.Player.TakeDamage(1);
                Destroy();
                return;
            }

            if (hitCollider.gameObject.CompareTag("Bullet"))
            {
                Bullet bullet = hitCollider.gameObject.GetComponent<Bullet>();
                if (bullet != null)
                {
                    TakeDamage(3);
                    bullet.Destroy();
                    return;
                }
            }
        }
    }       
}
