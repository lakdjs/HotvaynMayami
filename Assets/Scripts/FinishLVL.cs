using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLVL : MonoBehaviour
{
    [SerializeField] private PrefsSaver _prefsSaver;
    public int quantity;
    
    private void Update()
    {
        if(quantity<=0)
        {
            _prefsSaver.UnLockLevel();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
