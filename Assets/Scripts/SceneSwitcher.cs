using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Sceneswitching(string name)
    {
        SceneManager.LoadScene(name);
    }
}
