using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Image[] CutImage;
    public TextMeshProUGUI PressSpace;
    public Image TitleImage;
    public AudioSource AL;
    bool isListen = true;

    public void ChangeScene()
    {
        SceneManager.LoadScene("ChoiceScene");
    }
    public void CreateMode()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        isListen = !isListen;
        if (isListen)
        {
            AL.volume = 1.0f;
        }
        if (!isListen)
        {
            AL.volume = 0f;
        }
    }

}
