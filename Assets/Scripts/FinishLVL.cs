using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLVL : MonoBehaviour
{
    public int quantity;
    private void Update()
    {
        if(quantity<=0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
