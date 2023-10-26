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
        // из номера вопроса вычитаем длину листа
        // 2 - list count, 5 - nomerVopros
        // delta = 5 - 2 = 3
        int delta = NomerVopros - classVoprosOtvet.List.Count;
        for (int i = 0; i <= delta; i++)
        {
            classVoprosOtvet.Add(new VoprosOtvet());


            classVoprosOtvet.List[^1].Otvet = new string[4];
            // classVoprosOtvet.List[classVoprosOtvet.List.Count - 1] обращение к последниму элименту массива строка 27
        }

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
