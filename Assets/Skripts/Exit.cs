using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // ���������� ����� = 200��
    float vremy = 500f / 1000f;
    // ���� ����� ������� V ��� 
    float V = 0f;

    // ������ ����:
    void Update()
    {
        // ���� ����� Esc, ��:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.time - V >= vremy)
            {
                V= Time.time;
            }
            else Application.Quit(); // ����� ����� ������ �� ���� ��������� 
        }
        
    }
}

/*


���������� ����� = 200��
 ���� ����� ������� V ��� 
 

������ ����:
    ���� ����� Esc, ��:
        ���� (Time.time ������� ����� - V >= vremy)

                   {�� V= Time.time}
         ����� ����� ������ �� ����

 
 
*/