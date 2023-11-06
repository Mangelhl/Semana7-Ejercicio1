using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameInfo
{
    void UpdateInfo(int level, int time, int enemiesKilled, int playerHealth);
}
