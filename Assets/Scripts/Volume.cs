using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _slider2;
    private void Update()
    {
        LocalVolume();
        GlobalVolume();
    }
    public void LocalVolume()
    {
        _source.volume = _slider.value;
    }
    public void GlobalVolume()
    {
        AudioListener.volume = _slider2.value;
    }
}
