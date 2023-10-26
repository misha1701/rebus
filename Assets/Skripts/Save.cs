using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Save
{
    public static ClassVoprosOtvet classVoprosOtvet;

    static Save()
    {
        classVoprosOtvet = new ClassVoprosOtvet();
        if (PlayerPrefs.HasKey("state") == false)//���� � ��� ���� ����� 
        // if (!PlayerPrefs.HasKey("state"))
        {
            //��������� ��������� ClassVoprosOtvet
            PlayerPrefs.SetString("state", JsonUtility.ToJson(classVoprosOtvet));
        }
        else
        {
            classVoprosOtvet = GetClassVoprosOtvet();
        }
    }

    public static void SaveText(string text, int NomerVopros, int NomerButten)
    {
        // �� ������ ������� �������� ����� �����
        // 2 - list count, 5 - nomerVopros
        // delta = 5 - 2 = 3
        int delta = NomerVopros - classVoprosOtvet.List.Count;
        for (int i = 0; i <= delta; i++)
        {
            classVoprosOtvet.Add(new VoprosOtvet());


            classVoprosOtvet.List[^1].Otvet = new string[4];
            // classVoprosOtvet.List[classVoprosOtvet.List.Count - 1] ��������� � ���������� �������� ������� ������ 27
        }

        classVoprosOtvet.List[NomerVopros].Otvet[NomerButten] = text;
        PlayerPrefs.SetString("state", JsonUtility.ToJson(classVoprosOtvet));//ToJson ������ ����������� ������ � ��������� ���������
    }

    private static ClassVoprosOtvet GetClassVoprosOtvet()
    {
        string json = PlayerPrefs.GetString("state");
        // cvo - Class Vopros Otvet
        ClassVoprosOtvet cvo = JsonUtility.FromJson<ClassVoprosOtvet>(json);//  JsonUnitilite.FromJson| ���������� ������� �� ������ �������� 
        return cvo;
    }
}
