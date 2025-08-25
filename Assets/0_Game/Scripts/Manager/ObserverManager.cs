using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    public static Action OnUpdateScore;
    public static Action OnChooseLevel;
    public static Action<string> OnPlayerEndGame;
}
