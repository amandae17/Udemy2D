using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public static GameController gc;
    public Text pontosUI;
    public int bonus;

    private Player gcPlayer;



    private void Awake()
    {
        if (gc == null)
        {
            gc = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (gc != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RefreshScreen();
    }

    public void SetBonus(int newBonus)
    {
        bonus = newBonus;
        RefreshScreen();
    }

    public void RefreshScreen()
    {
        if (pontosUI != null)
        {
            pontosUI.text = bonus.ToString();
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}




//public void SetBonus(int newBonus)
//{
//    bonus = newBonus;
//    pontosUI.text = bonus.ToString(); // Update the UI text when the bonus changes
//    Debug.Log(bonus);
//}
//
//public void RefreshScreen()
//{
//    GameObject scoreText = GameObject.Find("Ponto");
//    if (scoreText != null)
//    {
//        scoreText.GetComponent<Text>().text = bonus.ToString();
//    }
//}
//private void Awake()
//    {
//        if (gc == null)
//        {
//            gc = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else if (gc != this)
//        {
//            Destroy(gameObject);
//        }
//    }
    //private void Start()
    //{
    //    RefreshScreen();
    //}

    //public void ChangeScene(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName); ;
    //}

//}