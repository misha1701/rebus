using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField Vopros;//  вопрос
    [SerializeField] private Button[] buttons;//  кнопки 
    [SerializeField] private TMP_InputField[] texts;// текст
    [SerializeField] private AudioSource[] audioSource;// аудио

    private int NomerVopros = -1;
    int vopsosLength = 5;

    public int GetNomerVopros()
    {
        return NomerVopros;
    }

    private void PokozSledVopros()
    {
        if (NomerVopros < vopsosLength)
        {
            NomerVopros++;

            ShowVoprosOtvet();
            VorvratRazmer();
        }


    }

    private void PokozPredVopros()
    {
        if (NomerVopros > 0)
        {
            NomerVopros--;

            ShowVoprosOtvet();
            VorvratRazmer();
        }



    }

    private void ShowVoprosOtvet()
    {
        // Vopros.text = voprosotvet[NomerVopros].Vopros;
        List<VoprosOtvet> list = Save.classVoprosOtvet.List;

        if (list.Count <= NomerVopros)
        {
            return;
        }

        GameObject[] rightAnswers = GameObject.FindGameObjectsWithTag("RightAnswer");
        for (int i = 0; i < rightAnswers.Length; i++)
        {
            Toggle toggle = rightAnswers[i].GetComponentInChildren<Toggle>();
            toggle.isOn = Save.classVoprosOtvet.List[NomerVopros].PravOtvetIndex == i;
        }

        Vopros.text = list[NomerVopros].Vopros;

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = list[NomerVopros].Otvet[i];
        }
    }

    private void Start()
    {
        PokozSledVopros();

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => OntBatoonClic(index));
        }
        // AddListener - включение на ивент, включение метода после клика


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PokozSledVopros();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PokozPredVopros();
        }
    }

    private void OntBatoonClic(int index) // index отвечает за нажатую кнопку
    {
        int pravelknopka = Save.classVoprosOtvet.List[NomerVopros].PravOtvetIndex;
        if (pravelknopka == index)
        {
            if (buttons[pravelknopka].transform.parent.localScale.x < 1.01f)
            {
                buttons[pravelknopka].transform.parent.localScale = buttons[pravelknopka].transform.parent.localScale + new Vector3(0.1f, 0.1f, 0.1f);
                // buttons[pravelknopka].transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                // .parent изменение родительского объекта
            }
            AudioWin();
        }
        else AudioNot();
    }


    private void VorvratRazmer()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);

        }


    }
    private void AudioWin()
    {
        audioSource[1].Play();
    }// Play- проигрывание главной музыки, PlayOneShot - проигрываение конкретной музыки на текущем audioSource

    private void AudioNot()
    {
        audioSource[0].Play();
    }


}

