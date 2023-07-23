using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objeler; 
    public float aktiflesmeSuresi = 3.0f;
    public int siradakiObje = 0; 
    public int spawnedCarCount = 0; 
    public int initialCarCount = 5; 
    public float speedMultiplier = 2.0f;

    void Start()
    {

        InvokeRepeating("Aktiflestir", aktiflesmeSuresi, aktiflesmeSuresi); //InvokeRepeating kullanarak "Aktiflestir" fonksiyonunu belirtilen süre aralýklarýyla çaðýr.
    }

   
    void Aktiflestir()
    {
        GameObject yeniObj = Instantiate(objeler[siradakiObje]);
        moveCar carScript = yeniObj.GetComponent<moveCar>();

        if (carScript != null)
        {
          
            if (spawnedCarCount >= initialCarCount)
            {
                carScript.speed = (int)(carScript.speed * speedMultiplier); 
            }
        }

        siradakiObje++;
        if (siradakiObje >= objeler.Length)
        {
            siradakiObje = 0;
        }

        spawnedCarCount++;
    }
    
}
