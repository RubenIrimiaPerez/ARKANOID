using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivePW : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto que ha tocado el power-up es el jugador
        if (other.CompareTag("Player"))
        {
            // Obtener el componente ObjectSpawner en la escena
            Spawner objectSpawner = FindObjectOfType<Spawner>();

            // Verificar si se encontró un ObjectSpawner en la escena
            if (objectSpawner != null)
            {
                // Activar el power-up llamando al mét
                objectSpawner.ActivatePowerUp3();
            }

            // Destruir el power-up después de ser activado
            Destroy(gameObject);
        }
    }
}

