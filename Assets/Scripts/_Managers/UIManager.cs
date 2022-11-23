using UnityEngine;

namespace EKTemplate
{
    public class UIManager : MonoBehaviour
    {
        //public MainPanel mainPanel;

        #region Singleton
        public static UIManager instance = null;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        #endregion

        private void Start()
        {
            //mainPanel.Active(true);
            //LevelManager.instance.startEvent.AddListener(StartGame);
        }
        public void StartGame()
        {
            //mainPanel.ActiveSmooth(false);
        }
      
    }
}