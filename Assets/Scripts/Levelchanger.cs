using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levelchanger : MonoBehaviour
{
    public int A;
    public void thislevel()
    {
        SceneManager.LoadScene(int.Parse(EventSystem.current.currentSelectedGameObject.transform.name));
    }
}
