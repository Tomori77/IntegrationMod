using UnityEngine;

namespace IntegrationMod
{
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        void Awake()
        {
            Debug.Log("IntegrationMod Loaded.");
        }

        void OnEnable()
        {
            IntegrationService.Initialize();
        }

        void OnDisable()
        {
            IntegrationService.Shutdown();
        }
    }
}