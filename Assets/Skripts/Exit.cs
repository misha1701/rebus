using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // переменная время = 200мс
    float vremy = 500f / 1000f;
    // флот время нажатия V еск 
    float V = 0f;

    // каждый кадр:
    void Update()
    {
        // если нажат Esc, то:
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.time - V >= vremy)
            {
                V= Time.time;
            }
            else Application.Quit(); // иначе метод выхода из игры встроеный 
        }
        
    }
}

/*


переменная время = 200мс
 флот время нажатия V еск 
 

каждый кадр:
    если нажат Esc, то:
        если (Time.time текущее время - V >= vremy)

                   {то V= Time.time}
         иначе метод выхода из игры

 
 
*/