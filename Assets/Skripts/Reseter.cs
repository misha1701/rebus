using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    [Tooltip("����� �� �������� ��� ���������")]
    [SerializeField] private bool needToReset;

    // Start is called before the first frame update
    void Start()
    {
        if (needToReset)
        {
            // ������� ��� ����� � �������� �� ������
            PlayerPrefs.DeleteAll();
        }
    }
}
