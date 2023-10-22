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
    [SerializeField] private TMP_InputField Vopros;
    [SerializeField] private Button[] buttons;
    [SerializeField] private TMP_InputField[] texts;
    [SerializeField] private VoprosOtvet[] voprosotvet;
    [SerializeField] private AudioSource[] audioSource;
   
     int  NomerVopros = -1;

    private void PokozSledVopros()
    {
        if (NomerVopros < voprosotvet.Length)
        {
            NomerVopros++;

            ShowVoprosOtvet();
            VorvratRazmer();
        }
        
        
    }

    private void PokozPredVopros()
    {
        if ( NomerVopros > 0)
        {
             NomerVopros--;

            ShowVoprosOtvet();
            VorvratRazmer();
        }
        
            
             
    }

    private void ShowVoprosOtvet()
    {
        Vopros.text = voprosotvet[NomerVopros].Vopros;

        for (int i = 0; i < buttons.Length; i++)
        {
            TMP_InputField text = texts[i];
            text.text = voprosotvet[NomerVopros].Otvet[i];
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
        
        int pravelknopka = voprosotvet[NomerVopros].PolucitPravelOtvet();
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
            buttons[i].GetComponent<Transform>().localScale = new Vector3(1,1,1);

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

