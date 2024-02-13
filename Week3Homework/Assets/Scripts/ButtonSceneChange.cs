using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonSceneChange : MonoBehaviour
{
    public GameObject gameManagerHolder;
    public GameObject currentLineActual;
    public GameObject currentLineCanvas;
  public void IntroButton() //function to use on click event 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load Scene through getting the current scene and continuing by 1 in the build settings index
    }

  // this is used to switch the location of displaying the saved poem amongst 2 different canvases
    public void ChangePoemText()
    {
        currentLineCanvas.SetActive(true);
        gameManagerHolder.GetComponent<GameManager>().poemText = currentLineActual.GetComponent<TextMeshProUGUI>();
    }
    
}
