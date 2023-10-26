using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnOFF : MonoBehaviour

{
    [SerializeField] UiManager uiManager;
    [SerializeField] Button buttonOn;
    [SerializeField] Button buttonOff;


    private void Start()
    {
        buttonOn.gameObject.SetActive(false);
        buttonOff.gameObject.SetActive(true);

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NevidButten");

        GameObject[] Otvet = GameObject.FindGameObjectsWithTag("Otvet");
        TMP_InputField[] inputFields = new TMP_InputField[Otvet.Length];
        for (int i = 0; i < Otvet.Length; i++)
        {
            inputFields[i] = Otvet[i].GetComponentInChildren<TMP_InputField>();
        }


        GameObject[] rightAnswers = GameObject.FindGameObjectsWithTag("RightAnswer");//RightAnswer перевод правильный ответ
        Toggle[] toggles = new Toggle[rightAnswers.Length];
        for (int i = 0; i < rightAnswers.Length; i++)
        {
            toggles[i] = rightAnswers[i].GetComponentInChildren<Toggle>();
            toggles[i].gameObject.SetActive(false);
        }


        buttonOn.onClick.AddListener(
            () =>
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(false);
                }
                for (int i = 0;i < toggles.Length; i++)
                {
                    toggles[i].gameObject.SetActive(true);
                }
                buttonOn.gameObject.SetActive(false);
                buttonOff.gameObject.SetActive(true);
            }
        );

        buttonOff.onClick.AddListener(
            () =>
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].SetActive(true);
                }
                for (int i = 0; i < toggles.Length; i++)
                {
                    toggles[i].gameObject.SetActive(false);
                }


                for (int i = 0; i < toggles.Length; i++)
                {
                    if (toggles[i].isOn) // isOn смотрит включён ли  
                    {
                        Save.classVoprosOtvet.List[uiManager.GetNomerVopros()].PravOtvetIndex = i;
                    }
                }

                for (int i = 0; i < Otvet.Length; i++)
                {
                    Save.SaveText(inputFields[i].text, uiManager.GetNomerVopros(), i);
                }

                buttonOff.gameObject.SetActive(false);
                buttonOn.gameObject.SetActive(true);
            }
        );
    }
}
