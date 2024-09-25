using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
    }
}
