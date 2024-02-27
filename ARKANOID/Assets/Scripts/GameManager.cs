using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//para poder cambiar de escena
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int blocksLeft;

    public static GameManager Instance{ get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
    }

    void Start()
    {

        //para saber cuantos bloques quedan buscandolo por tag , ya que todos los bloques tienen el tag "Block"
        blocksLeft = GameObject.FindGameObjectsWithTag("Block").Length;
    }

   //metodo para cada vez que se rompa un bloque
   public  void BlockDestroyed()
    {
        // se resta uno a los bloques que faltan y si los bloques que faltan por romper  y si blocksleft es igual a 0 se llama aun metodo para pasar de nivel
        blocksLeft--;
        if(blocksLeft <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()

    {
        // coge el indice de la escena en la que estas y le suma 1 . ejem( si estas en nivel 1 pues pasa al 2)
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex)+1);
    }

    // se puede llamar a este metodo desde otros scripts
    public void ReloadScene()

    {
        // cuando pierde se reinica al primer nivel
        SceneManager.LoadScene(0);
    }
}
