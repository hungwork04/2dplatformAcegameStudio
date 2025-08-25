using UnityEngine;

public class PrefData : MonoBehaviour
{
#if UNITY_EDITOR
	#region EXAM

	public static bool ExamBool
	{
		get => PlayerPrefs.GetInt("exam_bool", 1) == 1;
		set => PlayerPrefs.SetInt("exam_bool", value ? 1 : 0);
	}
	
	public static int ExamInt
	{
		get => PlayerPrefs.GetInt("exam_int", 0);
		set => PlayerPrefs.SetInt("exam_int", value);
	}

	public static float ExamFloat
	{
		get => PlayerPrefs.GetFloat("exam_float", 0);
		set => PlayerPrefs.SetFloat("exam_float", value);
	}

	public static string ExamString
	{
		get => PlayerPrefs.GetString("exam_string");
		set => PlayerPrefs.SetString("exam_string", value);
	}
	
	
	//Use when need to load with index
	public static int GetExam(int index)
	{
		return PlayerPrefs.GetInt("exam_" + index, 0);
	}

	//Use when need to save with index
	public static void SetExam(int index, int value)
	{
		PlayerPrefs.SetInt("exam_" + index, value);
	}


	#endregion
#endif
	
	#region USER

	public static bool FirstTimeOpen
	{
		get => PlayerPrefs.GetInt("first_time_open", 1) == 1;
		set => PlayerPrefs.SetInt("first_time_open", value ? 1 : 0);
	}

	public static int UserMoney
	{
        #if UNITY_EDITOR
		get => PlayerPrefs.GetInt("user_money", 50000);
        #elif !UNITY_EDITOR
        get => PlayerPrefs.GetInt("coin", 0);
        #endif
		set => PlayerPrefs.SetInt("user_money", value);
	}

	public static int UserLevel
	{
		get => PlayerPrefs.GetInt("user_level", 0);
		set => PlayerPrefs.SetInt("user_level", value);
	}
	
	
	public static bool AppRated
	{
		get => PlayerPrefs.GetInt("app_rated", 0) == 1;
		set => PlayerPrefs.SetInt("app_rated", value ? 1 : 0);
	}
	
	#endregion
	
	#region SETTINGS
	
	
	public static bool SettingMusic
	{
		get => PlayerPrefs.GetInt("setting_music", 1) == 1;
		set => PlayerPrefs.SetInt("setting_music", value ? 1 : 0);
	}

	public static bool SettingSFX
	{
		get => PlayerPrefs.GetInt("setting_sfx", 1) == 1;
		set => PlayerPrefs.SetInt("setting_sfx", value ? 1 : 0);
	}
	
	public static bool SettingVibrate
	{
		get => PlayerPrefs.GetInt("setting_vibrate", 1) == 1;
		set => PlayerPrefs.SetInt("setting_vibrate", value ? 1 : 0);
	}
	
	//Slider
	/*
	public static float SettingMusic
	{
		get => PlayerPrefs.GetFloat("setting_music", 1);
		set => PlayerPrefs.SetFloat("setting_music", value);
	}
    
	public static float SettingSFX
	{
		get => PlayerPrefs.GetFloat("setting_sfx", 1);
		set => PlayerPrefs.SetFloat("setting_sfx", value);
	}
	*/
	
	//Use when localization is available
	public static int SettingLanguageIndex
	{
		get => PlayerPrefs.GetInt("language", -1);
		set => PlayerPrefs.SetInt("language", value);
	}

    #endregion

    #region PLAYER INFO

	public static int Money
	{
        get => PlayerPrefs.GetInt("money", 0);
        set => PlayerPrefs.SetInt("money", value);
    }

    public static int HighScore
    {
        get => PlayerPrefs.GetInt("high_score", 0);
        set => PlayerPrefs.SetInt("high_score", value);
    }

    public static int SelectedSkin
    {
        get => PlayerPrefs.GetInt("selected_skin", 0);
        set => PlayerPrefs.SetInt("selected_skin", value);
    }
    public static int Level
    {
        get => PlayerPrefs.GetInt("Level", 0);
        set => PlayerPrefs.SetInt("Level", value);
    }
    #endregion
}
