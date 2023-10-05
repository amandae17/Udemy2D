using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public bool isDead = false; // Controla o estado do jogador

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        isDead = true;
        // Aqui você pode adicionar a lógica para reiniciar o jogo
        // Por exemplo, carregar uma cena de game over, reiniciar a posição do jogador, etc.
    }
}