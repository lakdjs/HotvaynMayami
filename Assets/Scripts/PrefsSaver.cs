using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefsSaver : MonoBehaviour
{
    private void Start()
    {
        UnLockLevel();
    }
    public void UnLockLevel()
    {
        int currentLevel = (SceneManager.GetActiveScene().buildIndex) - 1;

        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }
}
