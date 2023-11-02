using System;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnOFF : MonoBehaviour

{
    [SerializeField] UiManager uiManager;
    [SerializeField] Image Izmenenia;

    private Toggle[] toggles;
    private GameObject[] gameObjects;
    private GameObject[] Otvet;
    private TMP_InputField[] inputFields;
    public bool IsIzmenenia;

    private void Start()
    {
        Izmenenia.gameObject.SetActive(false);

        gameObjects = GameObject.FindGameObjectsWithTag("NevidButten");

        Otvet = GameObject.FindGameObjectsWithTag("Otvet");
        inputFields = new TMP_InputField[Otvet.Length];
        for (int i = 0; i < Otvet.Length; i++)
        {
            inputFields[i] = Otvet[i].GetComponentInChildren<TMP_InputField>();
        }


        GameObject[] rightAnswers = GameObject.FindGameObjectsWithTag("RightAnswer");//RightAnswer перевод правильный ответ
        toggles = new Toggle[rightAnswers.Length];
        for (int i = 0; i < rightAnswers.Length; i++)
        {
            toggles[i] = rightAnswers[i].GetComponentInChildren<Toggle>();
            toggles[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (IsIzmenenia)
            {
                NoRedakt(gameObjects, Otvet, inputFields, toggles);
            }
            else
            {
                VklRedakt(gameObjects, toggles);
            }

            IsIzmenenia = !IsIzmenenia;
        }
    }

    /// <summary>
    /// сохранить результат редактирования
    /// </summary>
    public void SaveMetod()
    {
        SaveMetod(Otvet, inputFields, toggles);
    }

    private void NoRedakt(GameObject[] gameObjects, GameObject[] Otvet, TMP_InputField[] inputFields, Toggle[] toggles)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(true);
        }
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].gameObject.SetActive(false);
        }

        SaveMetod(Otvet, inputFields, toggles);

        Izmenenia.gameObject.SetActive(false);
    }

    private void SaveMetod(GameObject[] Otvet, TMP_InputField[] inputFields, Toggle[] toggles)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn) // isOn смотрит включён ли  
            {
                Save.classVoprosOtvet.ExtendList(uiManager.GetNomerVopros());
                Save.classVoprosOtvet.List[uiManager.GetNomerVopros()].PravOtvetIndex = i;
            }
        }

        for (int i = 0; i < Otvet.Length; i++)
        {
            Save.SaveText(inputFields[i].text, uiManager.GetNomerVopros(), i);
        }
    }

    private void VklRedakt(GameObject[] gameObjects, Toggle[] toggles)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].gameObject.SetActive(true);
        }

        Izmenenia.gameObject.SetActive(true);
    }
}
