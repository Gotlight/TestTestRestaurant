using System;
using System.Diagnostics;

public class DebugUtils
{
    [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]       
    public static void Assert(bool trueCondition, string errorMessage = "")
    {
        if (!trueCondition)
            UnityEngine.Debug.LogError(errorMessage);
//            throw new Exception(errorMessage);
    }
}