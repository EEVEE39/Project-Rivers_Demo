using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    
    void Update (){
        if(Input.GetKeyUp(KeyCode.Z)){
                SceneManager.LoadScene(3);
            }
    }

}