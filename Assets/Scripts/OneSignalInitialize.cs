using OneSignalSDK;
using UnityEngine;


public class OneSignalInit : MonoBehaviour
{
    [SerializeField] private string _key = "635c5f12-bb1c-4e8a-92a5-65636c604328";
    
    
    private void Start()
    {
        OneSignal.Default.Initialize(_key);
    }
}