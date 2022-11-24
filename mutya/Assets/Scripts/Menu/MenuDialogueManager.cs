using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDialogueManager : MonoBehaviour
{
    public static bool q1 = false;
    public static bool dialogue1 = false;
    public static bool dialogue2 = false;
    public static bool dialogue3 = false;

    public bool getQ1()
    {
        return q1;
    }

    public void setQ1(bool val)
    {
        q1 = val;
    }

    public bool getD1()
    {
        return dialogue1;
    }

    public bool getD2()
    {
        return dialogue2;
    }

    public bool getD3()
    {
        return dialogue3;
    }

    public void setD1(bool val)
    {
        dialogue1 = val;
    }

    public void setD2(bool val)
    {
        dialogue2 = val;
    }

    public void setD3(bool val)
    {
        dialogue3 = val;
    }
}
