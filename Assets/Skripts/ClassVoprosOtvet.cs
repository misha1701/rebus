using System;
using System.Collections.Generic;

[Serializable]
public class ClassVoprosOtvet
{
    public List<VoprosOtvet> List;
    
    public ClassVoprosOtvet()
    {
        List = new List<VoprosOtvet>();
    }

    /// <summary>
    /// расширяет список 
    /// </summary>
    public void ExtendList(int index)
    {
        for (int i = List.Count; i <= index; i++)
        {
            List.Add(new VoprosOtvet());
        }
    }
}
