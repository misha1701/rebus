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
        if (PlayerPrefs.HasKey("state") == false)//если у нас нету ключа 
        // if (!PlayerPrefs.HasKey("state"))
        {
            //сохраняем дефолтный ClassVoprosOtvet
            PlayerPrefs.SetString("state", JsonUtility.ToJson(classVoprosOtvet));
        }
        else
        {
            classVoprosOtvet = GetClassVoprosOtvet();
        }
    }

    public static void SaveText(string text, int NomerVopros, int NomerButten)
    {
        classVoprosOtvet.List[NomerVopros].Otvet[NomerButten] = text;
        PlayerPrefs.SetString("state", JsonUtility.ToJson(classVoprosOtvet));//ToJson формат переведения класса в текстовое состояние
    }

    private static ClassVoprosOtvet GetClassVoprosOtvet()
    {
        string json = PlayerPrefs.GetString("state");
        // cvo - Class Vopros Otvet
        ClassVoprosOtvet cvo = JsonUtility.FromJson<ClassVoprosOtvet>(json);//  JsonUnitilite.FromJson| возвращаем обратно из страки значения 
        return cvo;
    }
}
