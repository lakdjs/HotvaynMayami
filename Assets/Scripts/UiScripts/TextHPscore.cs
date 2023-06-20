using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHPscore : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private TMP_Text _textHP;
    public int Score;
    private void Update()
    {
            _textHP.text = "Health " + _playerStats.HP;
            _textScore.text = "Score " + Score;
    }
}
