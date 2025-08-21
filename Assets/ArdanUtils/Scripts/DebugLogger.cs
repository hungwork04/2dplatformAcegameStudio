using UnityEngine;

public static class DebugLogger
{
    public static void Log(this MonoBehaviour mono, object message)
    {
#if UNITY_EDITOR || ENABLE_LOG
        string scriptName = mono.GetType().Name;
        Debug.Log($"{scriptName} Log: {message}", mono.gameObject);
#endif
    }

    public static void LogWarning(this MonoBehaviour mono, object message)
    {
#if UNITY_EDITOR || ENABLE_LOG
        string scriptName = mono.GetType().Name;
        Debug.LogWarning($"{scriptName}: {message}", mono.gameObject);
#endif
    }

    public static void LogError(this MonoBehaviour mono, object message)
    {
#if UNITY_EDITOR || ENABLE_LOG
        string scriptName = mono.GetType().Name;
        Debug.LogError($"{scriptName}: {message}", mono.gameObject);
#endif
    }
}
