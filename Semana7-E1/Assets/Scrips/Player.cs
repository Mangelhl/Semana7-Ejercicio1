using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : GameCharacter
{
    public Text playerNameText;
    public Text playerStatsText;

    public Situation1 situation1;
    public Situation2 situation2;
    public Situation3 situation3;

    int finalesAlcanzados = 0;

    void Start()
    {
        CreateCharacter(30, 30, 40);
        UpdateInfo();
    }

    void Update()
    {
        if (Life <= 0)
        {
            Debug.Log("¡Has perdido! Tu vida ha llegado a 0.");
            RestartGame();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Force >= situation1.ForceRequired && Skill >= situation1.RequiredSkill)
                {
                    situation1.ShowText();
                }
                else
                {
                    Debug.Log("No tienes los requisitos necesarios para esta opción.");
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Force >= situation2.ForceRequired && Skill >= situation2.RequiredSkill)
                {
                    situation2.ShowText();
                }
                else
                {
                    Debug.Log("No tienes los requisitos necesarios para esta opción.");
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (Force >= situation3.ForceRequired && Skill >= situation3.RequiredSkill)
                {
                    situation3.ShowText();
                }
                else
                {
                    Debug.Log("No tienes los requisitos necesarios para esta opción.");
                }
            }

            // Resto del código para manejar las opciones del jugador
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateInfo()
    {
        playerNameText.text = "Name: " + Name;
        playerStatsText.text = "Force: " + Force + " | Skill: " + Skill + " | Life: " + Life;
    }

    public override void CreateCharacter(int force, int skill, int life)
    {
        if (force + skill + life <= 100)
        {
            Name = "Player";
            Force = force;
            Skill = skill;
            Life = life;
        }
        else
        {
            Debug.LogError("The sum of strength, dexterity and life must not be greater than 100.");
        }
    }

    void AlcanzarFinal()
    {
        finalesAlcanzados++;

        if (finalesAlcanzados >= 3)
        {
            MostrarFinalDelJuego();
        }
    }
    void MostrarFinalDelJuego()
    {
        Debug.Log("¡Has alcanzado los tres finales diferentes!");
        SceneManager.LoadScene("FinalScene");
    }

}