using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsDeleter : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
