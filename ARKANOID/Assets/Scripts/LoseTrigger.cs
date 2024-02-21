using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// este script esta hecho para que cuando la bola choque con el boxcollider 
//llame al metodo ReloadScene que reinicia a la escena principal
public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.ReloadScene();
    }
}
