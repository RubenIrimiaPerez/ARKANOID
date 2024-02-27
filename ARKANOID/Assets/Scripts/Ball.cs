using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 initialVelocity;

    //creamos esta variable porque depende el nivel puede variar la velocidad
    [SerializeField] private float velocityMultiplier;

    private Rigidbody2D ballRb;
    private bool isBallMoving;
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       #if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

        //lanzar la bola con el espacio ,mientras se este quieto
        if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
        {
            Launch();
        }

#elif UNITY_ANDROID

        //Verificar si se ha tocado la pantalla (para dispositivos móviles)

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !isBallMoving)
            {
                Launch();
            }
        }


#endif


    }

    private void Launch()
    {
        transform.parent = null;
        ballRb.velocity = initialVelocity;
        isBallMoving = true;
    }


    // para que cuando la pelota choque con un bloque se rompa
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // si el objeto tiene la tag "Block" y se choca se destruye
        if (collision.gameObject.CompareTag("Block"))
        { 
            Destroy(collision.gameObject);

            // Esta linea es para que cada vez que se rompe un bloque se añade velocidad
            ballRb.velocity *= velocityMultiplier;


             // llama al metodo del game manager cada vez que se rompe un bloque 
            GameManager.Instance.BlockDestroyed();
        }
        VelocityFix();
    }
      // metodo para cuando la pelota se queda bugueada 
    private void VelocityFix()
    {
        float velocityDelta = 0.5f;
        float minVelocity = 0.2f;

        //cuando la pelota se queda atacada moviendose de manera vertical
        if(Mathf.Abs(ballRb.velocity.x) < minVelocity)
        {

            // sale la pelota en horizontal de manera aleatoria ya sea para la derch o izq
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(velocityDelta, 0f);
        }
        //cuando la pelota se queda atacada moviendose de manera horizontal
        if (Mathf.Abs(ballRb.velocity.y) < minVelocity)
        {

            // sale la pelota en vertical de manera aleatoria ya sea para arriba o abajo
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballRb.velocity += new Vector2(0f,velocityDelta);
        }
    }

}
