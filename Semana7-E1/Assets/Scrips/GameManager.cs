using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player { get; set; }

    private static GameManager instance;
    private int level;
    private List<Enemy> Enemies = new List<Enemy>();
    private List<Enemy2> Enemies2 = new List<Enemy2>();
    private List<Bullet> bullets = new List<Bullet>();

    public void AddBullet(Bullet bullet)
    {
        bullets.Add(bullet);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>(); 
            }
            return instance;
        }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }

    public void AddEnemy2(Enemy2 enemy2)
    {
        Enemies2.Add(enemy2);
    }

    public List<Enemy> GetEnemies()
    {
        return Enemies;
    }
}