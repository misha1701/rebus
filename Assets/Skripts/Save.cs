using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class Save
{
    public static ClassVoprosOtvet classVoprosOtvet;

    private static string FileName = "state.json";

    static Save()
    {
        classVoprosOtvet = new ClassVoprosOtvet();

        if (File.Exists(FileName) == false)//���� � ��� ���� ����� 
        // if (!PlayerPrefs.HasKey("state"))
        {
            //��������� ��������� ClassVoprosOtvet
            File.WriteAllText(FileName, JsonUtility.ToJson(classVoprosOtvet, true));
            
        }
        else
        {
            classVoprosOtvet = GetClassVoprosOtvet();
        }
    }

    public static void SaveText(string text, int NomerVopros, int NomerButten)
    {
        classVoprosOtvet.List[NomerVopros].Otvet[NomerButten] = text;
        File.WriteAllText(FileName, JsonUtility.ToJson(classVoprosOtvet, true));
       // PlayerPrefs.SetString(json, JsonUtility.ToJson(classVoprosOtvet));//ToJson ������ ����������� ������ � ��������� ���������
    }

    private static ClassVoprosOtvet GetClassVoprosOtvet()
    {
        string json = File.ReadAllText(FileName);
        // cvo - Class Vopros Otvet
        ClassVoprosOtvet cvo = JsonUtility.FromJson<ClassVoprosOtvet>(json);//  JsonUnitilite.FromJson| ���������� ������� �� ������ �������� 
        return cvo;
    }
}
 