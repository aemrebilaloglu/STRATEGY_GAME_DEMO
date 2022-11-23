using UnityEngine;

namespace EKTemplate
{
    public class DataManager : MonoBehaviour
    {
        private readonly string MONEY_DATA = "money";
        private readonly string SOUND_DATA = "sound";

        public int money;
        public bool sound;

        #region Singleton
        public static DataManager instance = null;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
                GetDatas();
            }
            else
            {
                DestroyImmediate(this);
            }
        }
        #endregion

        private void GetDatas()
        {
            money = PlayerPrefs.GetInt(MONEY_DATA, 0);
            sound = PlayerPrefs.GetInt(SOUND_DATA, 1) == 1;
        }
        public void SetMoney(int _money)
        {
            money = _money;
            PlayerPrefs.SetInt(MONEY_DATA, money);
            PlayerPrefs.Save();
        }

        public void SetSound(bool isOn)
        {
            PlayerPrefs.SetInt(SOUND_DATA, isOn ? 1 : 0);
            PlayerPrefs.Save();
            sound = isOn;
        }
    }
}