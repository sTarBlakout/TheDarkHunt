using UnityEngine;

namespace Global
{
    public class GlobalData : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
