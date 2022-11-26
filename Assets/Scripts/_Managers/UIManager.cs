using UnityEngine;

    public class UIManager : MonoBehaviour
    {
        public GameObject barrack;
        public GameObject powerPlant;

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
        }
}