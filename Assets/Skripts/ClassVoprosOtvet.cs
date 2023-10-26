using System;
using System.Collections.Generic;

[Serializable] 
public class ClassVoprosOtvet
{
    public List<VoprosOtvet> List;
    public int Len;

    public ClassVoprosOtvet()
    {
        List = new List<VoprosOtvet>();
        Len = 0;
    }

    public void Add(VoprosOtvet voprosOtvet)
    {
        List.Add(voprosOtvet);
        Len++;
    }
}
