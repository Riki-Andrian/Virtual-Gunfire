using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public bool isGameActive;
    // Start is called before the first frame update
   public void StartGame(int difficulty)
    {    
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
