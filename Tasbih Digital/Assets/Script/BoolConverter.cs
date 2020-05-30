using UnityEngine;

public class BoolConverter : MonoBehaviour
{
    public static BoolConverter instance;
    
    public int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}

//https://stackoverflow.com/questions/41073236/how-to-save-bool-to-playerprefs-unity
