using UnityEngine;

public class DataController : MonoBehaviour
{
	public static DataController Instance;
	
	#region GET SET DATA
	
	//USER
	public static int UserMoney
	{
		get => _userMoney;
		set
		{
			_userMoney = value;
			PrefData.UserMoney = value;
		}
	}
	
	public static int UserLevel
	{
		get => _userLevel;
		set
		{
			_userLevel = value;
			PrefData.UserLevel = value;
		}
	}

	#endregion

	#region SETTING

	public static bool Setting_Music
	{
		get => _settingMusic;
		set
		{
			_settingMusic = value;
			PrefData.SettingMusic = value;
		}
	}
	
	public static bool Setting_SFX
	{
		get => _settingSFX;
		set
		{
			_settingSFX = value;
			PrefData.SettingSFX = value;
		}
	}
	
	//Slider
	/*
	public static float Setting_Music
	{
		get => _settingMusic;
		set
		{
			_settingMusic = value;
			UserData.SettingMusic = value;
		}
	} 
	
	public static float Setting_SFX
	{
		get => _settingSfx;
		set
		{
			_settingSfx = value;
			UserData.SettingSFX = value;
		}
	}
	*/
  

	public static bool Setting_Vibrate
	{
		get => _settingVibrate;
		set
		{
			_settingVibrate = value;
			PrefData.SettingVibrate = value;
		}
	}

    #endregion

    #region PLAYER INFOR
    public static int Money
    {
        get => _money;
        set
        {
            _money = value;
            PrefData.Money = value;
        }
    }

    public static int HighScore
    {
        get => _highscore;
        set
        {
            _highscore = value;
            PrefData.HighScore = value;
        }
    }

    public static int SelectedSkin
    {
        get => _selectedskin;
        set
        {
            _selectedskin = value;
            PrefData.SelectedSkin = value;
        }
    }

    public static int Level
    {
        get => _level;
        set
        {
            _level = value;
            PrefData.Level = value;
        }
    }
    #endregion


    #region CACHE

    //USER
    private static int _userMoney;
	private static int _userLevel;
	private static int _userRound;
	private static int _userSkin;
	private static int _userSkinType;
	
	//SETTING
	private static bool _settingMusic;
	private static bool _settingSFX;
	private static bool _settingVibrate;

	//PLAYER INFOR
	private static int _money;
	private static int _highscore;
	private static int _selectedskin;
	private static int _level;
	#endregion

	private void Awake()
	{
		if (Instance != null && Instance!= this)
		{
            Destroy(gameObject);
        }
        Instance = this;
		DontDestroyOnLoad(gameObject);

        _userMoney = PrefData.UserMoney;
		_userLevel = PrefData.UserLevel;

		_settingMusic = PrefData.SettingMusic;
		_settingSFX = PrefData.SettingSFX;
		_settingVibrate = PrefData.SettingVibrate;


		_money = PrefData.Money;
		_highscore = PrefData.HighScore;
		_selectedskin = PrefData.SelectedSkin;
		_level = PrefData.Level;
	}
	private void Start()
	{
		PrefData.Money = 0;
		_money = 20;
		PrefData.HighScore = 0;
		_highscore = 0;
		PrefData.SelectedSkin = 0;
		PrefData.Level = 0;
	}
#if UNITY_IOS
    public void ATT()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer && PlayerPrefs.GetInt("ATTShowed", 0) == 0 && UnityATTPlugin.Instance.IsIOS14AndAbove())
        {
            TrackingEvent.LogFirebase("ATTShow", new[] {new Parameter("ATTShow", "ATTShow")});
            UnityATTPlugin.Instance.ShowATTRequest((action) =>
            {
                if (action == ATTStatus.Authorized)
                {
                    AudienceNetwork.AdSettings.SetAdvertiserTrackingEnabled(true);
                    AdsAdapter.LogFirebase("ATTSuccess", new[] {new Parameter("ATTSuccess", "ATTSuccess")});
                }
                else{
                    AudienceNetwork.AdSettings.SetAdvertiserTrackingEnabled(false);
                }
            });
            PlayerPrefs.SetInt("ATTShowed", 1);
        }

    }
#endif
}
