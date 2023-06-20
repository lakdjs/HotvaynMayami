using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CheckingLVLs : MonoBehaviour
{
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private SceneSwitcher _sceneSwitcher;
    private Color c;
    private Color b;
    private void Start()
    {
         c = new Color(_texts[0].color.r, _texts[0].color.g, _texts[0].color.b, 0.5f);
         b = new Color(_texts[0].color.r, _texts[0].color.g, _texts[0].color.b, 1);
    }
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("levels"));
        if (PlayerPrefs.GetInt("levels") > 0)
        {
            _buttonText.text = "Continue";
            _buttonContinue.onClick.RemoveAllListeners();
            _buttonContinue.onClick.AddListener(_sceneSwitcher.SceneSwitching);
        }
        else
        {
            _buttonText.text = "Start"; 
        }
        for (int i = 0; i < _buttons.Length; i++)
        {
            if( PlayerPrefs.GetInt("levels")>=i)
            {
                _buttons[i].interactable = true;
                _texts[i].color = b;
            }
            else
            {
                _buttons[i].interactable = false;
                _texts[i].color = c;
            }
        }
    }
}
