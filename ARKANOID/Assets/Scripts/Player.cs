using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
        
    // para que no se pase de las paredes
    private float bounds = 4.5f;
  
   
    void Update()
    {
        Move();
    }

    private void Move()
    {
        //que se mueva en horizontal 
        float moveInput = Input.GetAxisRaw("Horizontal");


        Vector2 playerPosition = transform.position;
        playerPosition.x = Mathf.Clamp(playerPosition.x + moveInput * moveSpeed * Time.deltaTime, -bounds, bounds);
        transform.position = playerPosition;
    }
}
