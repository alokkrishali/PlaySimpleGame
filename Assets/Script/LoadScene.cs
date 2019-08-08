using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load_Question_1()
    {
        SceneManager.LoadScene("Q_1");
    }
    public void Load_Question_2()
    {
        SceneManager.LoadScene("Q_2");
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
