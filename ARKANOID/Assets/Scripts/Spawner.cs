using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class Spawner : MonoBehaviour
{
    // Prefab del power-up que se generará
    public GameObject powerUpPrefab;



    // Variable para asegurarse de que el power-up se genere solo una vez
    private bool hasSpawned = false;

    // Método Start se ejecuta una vez al inicio del juego
    private void Start()
    {
        // Se invoca la función SpawnPowerUp() después de 7 segundos
        Invoke("SpawnPowerUp", 7f);
    }

    // Método para generar el power-up
    private void SpawnPowerUp()
    {
        // Se verifica si el power-up ya ha sido generado
        if (!hasSpawned)
        {
            // Se instancia el power-up en el punto de generación
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            // Se marca el power-up como generado
            hasSpawned = true;
        }


    }

    // Método para activar el efecto del power-up (destruir todos los bloques)
    public void ActivatePowerUp3()
    {

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            // Se buscan todos los objetos con el tag "Block"
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

            // Se recorren todos los bloques encontrados y se destruyen
            foreach (GameObject block in blocks)
            {
                Destroy(block);

            }
            SceneManager.LoadScene(0);

        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameObject ball = GameObject.FindGameObjectWithTag("Player");

            if (ball != null)
            {
                // Obtener el Rigidbody2D de la bola
                Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

                // Aumentar la velocidad actual multiplicando por el multiplicador
                ballRb.velocity *= 1.1f;
            }

        }
        else
        {
            // Aumentar la velocidad de la bola en un 10%
            GameObject ball = GameObject.FindGameObjectWithTag("Player");

            if (ball != null)
            {
                // Obtener el Rigidbody2D de la bola
                Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();

                // Aumentar la velocidad actual multiplicando por el multiplicador
                ballRb.velocity *= 1.2f;
            }
        }
    }


}
