using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void RestartGame() {

        SceneManager.LoadScene("Gameplay");
        Destroy(GameObject.FindWithTag("Enemy"));
    }

    public void HomeButton() {
        SceneManager.LoadScene("MainMenu");


    }



}
