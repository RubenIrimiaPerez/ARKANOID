using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class Spawner2 : MonoBehaviour
{
    // Prefab del power-up que se generará
    public GameObject powerDownPrefab;


    // Variable para asegurarse de que el power-up se genere solo una vez
    private bool hasSpawned = false;

    // Método Start se ejecuta una vez al inicio del juego
    private void Start()
    {
        // Se invoca la función SpawnPowerDown() después de 7 segundos

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Invoke("SpawnPowerDown", 10f);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Invoke("SpawnPowerDown", 15f);
        }
    }

    // Método para generar el power-up
    private void SpawnPowerDown()
    {
        // Se verifica si el power-up ya ha sido generado
        if (!hasSpawned)
        {
            // Se instancia el power-up en el punto de generación
            Instantiate(powerDownPrefab, transform.position, Quaternion.identity);
            // Se marca el power-up como generado
            hasSpawned = true;
        }


    }

    // Método para activar el efecto del power-up (destruir todos los bloques)
    public void ActivatePowerDown()
    {
        SceneManager.LoadScene(0);
    }

}
