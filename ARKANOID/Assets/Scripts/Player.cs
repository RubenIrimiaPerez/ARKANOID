using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float bounds = 4.5f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
        transform.position = playerPosition;

#elif UNITY_ANDROID

// Moverse tocando y arrastrando la pantalla en dispositivos móviles

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Moved)
            {
            // Calcular la dirección del movimiento

                float moveInput = touch.deltaPosition.x * 0.01f;
                Vector2 playerPosition = transform.position;
                playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
                transform.position = playerPosition;
            }
        }
#endif
    }
}
