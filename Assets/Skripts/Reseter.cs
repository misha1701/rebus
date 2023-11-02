using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    [Tooltip("Нужно ли сбросить все настройки")]
    [SerializeField] private bool needToReset;

    // Start is called before the first frame update
    void Start()
    {
        if (needToReset)
        {
            // удалить все ключи и значения из памяти
            PlayerPrefs.DeleteAll();
        }
    }
}
