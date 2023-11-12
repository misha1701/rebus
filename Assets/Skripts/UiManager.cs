using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField Vopros;//  ������
    [SerializeField] private Button[] buttons;//  ������ 
    [SerializeField] private TMP_InputField[] texts;// �����
    [SerializeField] private AudioSource[] audioSource;// �����

    private int NomerVopros = -1;
    private SettingsOnOFF settingsOnOFF;
    private List<int> _yvelichinoLi;

    public int GetNomerVopros()
    {
        return NomerVopros;
    }

    private void PokozSledVopros()
    {
        // ���� ��������� ��������, �� �������� �� �����
        // �����, ���������, ����� ������� + 1 ����� ������, ��� ����� ������

        // || - ���
        // && - �
        
        if (settingsOnOFF.IsIzmenenia || (NomerVopros < Save.classVoprosOtvet.List.Count))
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
            toggle.isOn = Save.classVoprosOtvet.List[NomerVopros].PravOtvetIndex.Contains(i);
        }

        Vopros.text = list[NomerVopros].Vopros;

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = list[NomerVopros].Otvet[i];
        }
    }

    private void Start()
    {
        _yvelichinoLi = new List<int>();
        // ������������������������<��������������������������>
        settingsOnOFF = FindObjectOfType<SettingsOnOFF>();


        PokozSledVopros();

        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => OntBatoonClic(index));
        }
        // AddListener - ��������� �� �����, ��������� ������ ����� �����

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ���� �������� ���������, �� ��������� ���������
            if (settingsOnOFF.IsIzmenenia)
            {
                settingsOnOFF.SaveMetod();
            }
            PokozSledVopros();
            

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            // ���� �������� ���������, �� ��������� ���������
            if (settingsOnOFF.IsIzmenenia)
            {
                settingsOnOFF.SaveMetod();
            }
            PokozPredVopros();
            VorvratRazmer();
        }
    }

    private void OntBatoonClic(int index) // index �������� �� ������� ������
    {
        List<VoprosOtvet> list = Save.classVoprosOtvet.List;
        if (list.Count <= NomerVopros)
        {
            return;
        }
        
        if (Save.classVoprosOtvet.List[NomerVopros].PravOtvetIndex.Contains(index))
        {
            if (buttons[index].transform.parent.localScale.x < 1.01f)
            {
                _yvelichinoLi.Add(index);
                Anime(index).SetTrigger("ButtenClic");



                // buttons[pravelknopka].transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                // .parent ��������� ������������� �������
            }
            AudioWin();
        }
        else AudioNot();
    }

    private Animator Anime(int pravelknopka)
    {
        return buttons[pravelknopka].transform.parent.GetComponent<Animator>();
    }

    private void VorvratRazmer()
    {
        foreach (var item in _yvelichinoLi)
        {
            Anime(item).SetTrigger("Vozvrat");
        }
    }
    private void AudioWin()
    {
        audioSource[1].Play();
    }// Play- ������������ ������� ������, PlayOneShot - ������������� ���������� ������ �� ������� audioSource

    private void AudioNot()
    {
        audioSource[0].Play();
    }


}

