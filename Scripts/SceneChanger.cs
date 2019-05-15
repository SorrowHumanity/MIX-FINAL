using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("ForestScene");
    }

    public static void LoadScene2()
    {
        SceneManager.LoadScene("MountainScene");
    }

    public static void LoadScene3()
    {
        SceneManager.LoadScene("VillageScene");
    }

    public static void LoadScene4()
    {
        SceneManager.LoadScene("VictoryScene");
    }

    public void LoadSceneMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
