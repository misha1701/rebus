using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnOFF : MonoBehaviour

{
    [SerializeField] Button buttonOn;
    [SerializeField] Button buttonOff;

    private void Start()
    {
        buttonOn.onClick.AddListener(
            () =>
            {

            }
        );
    }
}
