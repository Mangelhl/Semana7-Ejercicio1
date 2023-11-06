using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : CustomGameObject, IGameInfo
{
    public Vector3 Direction { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public float FireRate { get; set; }
    public float MovementSpeed { get; set; } = 5.0f;

    public Transform bulletSpawnPoint;
    public float bulletForce = 10.0f;
    public GameObject bulletPrefab;

    private Rigidbody rb;    

    public Text levelText;
    public Text timeText;
    public Text enemiesKilledText;
    public Text playerHealthText;

    private int enemiesKilled = 0;

    void Start()
    {
        StartGame();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        StartCoroutine(LevelUpAutomatically());
    }

    void StartGame()
    {
        Level = 1;
        Health = 20;
        UpdateInfo(Level, 10, 0, Health);
    }

    private IEnumerator LevelUpAutomatically()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            int currentTime = int.Parse(timeText.text.Split(' ')[1]);

            if (currentTime > 0)
            {
                currentTime--;
            }

            UpdateInfo(Level, currentTime, enemiesKilled, Health);

            if (currentTime == 0)
            {
                if (Level < 10)
                {
                    LevelUp();
                }
            }
        }
    }

    public override void Update()
    {
        UpdateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        Collider[] hitColliders = Physics.OverlapBox(this.Position, new Vector3(1.0f, 1.0f, 1.0f));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Health -= enemy.Damage;
                }
            }

            else if (hitCollider.gameObject.CompareTag("Enemy2"))
            {
                Enemy2 enemy2 = hitCollider.gameObject.GetComponent<Enemy2>();
                if (enemy2 != null)
                {
                    Health -= enemy2.Damage;
                }
            }
        }
        if (enemiesKilled >= 100 || Level >= 10)
        {
            Debug.Log("¡El jugador ha ganado!");
        }
    }

    public void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Direction = this.Direction;
        bullet.Damage = 5;

        Rigidbody bulletRb = bulletObject.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletSpawnPoint.forward * bulletForce;

        Collider[] hitColliders = Physics.OverlapBox(bullet.Position, new Vector3(1.0f, 1.0f, 1.0f));

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy"))
            {
                Enemy enemy = hitCollider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(bullet.Damage);
                    bullet.Destroy();
                    return;
                }
            }
            else if (hitCollider.gameObject.CompareTag("Enemy2"))
            {
                Enemy2 enemy2 = hitCollider.gameObject.GetComponent<Enemy2>();
                if (enemy2 != null)
                {
                    enemy2.TakeDamage(bullet.Damage);
                    bullet.Destroy();
                    return;
                }
            }
        }
    }

    public void UpdateMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized * this.MovementSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    public void UpdateInfo(int level, int time, int enemiesKilled, int playerHealth)
    {
        levelText.text = "Nivel: " + level.ToString();
        timeText.text = "Tiempo: " + time.ToString() + " segundos";
        enemiesKilledText.text = "Enemigos abatidos: " + enemiesKilled.ToString();
        playerHealthText.text = "Vida: " + playerHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Debug.Log("El jugador se quedó sin vida.");
            Destroy();
        }
    }

    public void LevelUp()
    {
        Level++;
        FireRate -= 0.2f;
        FireRate = Mathf.Max(0.1f, FireRate);
        enemiesKilled = 0;

        if (Level <= 10)
        {
            UpdateInfo(Level, 10, enemiesKilled, Health);
        }
        else
        {
            Debug.Log("¡El jugador ha ganado!");
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;

        if (enemiesKilled >= 100 || Level >= 10)
        {
            Debug.Log("¡El jugador ha ganado!");
        }
    }
}
