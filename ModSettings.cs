using MelonLoader;
using UnityEngine;
using Il2CppInterop;
using Il2CppInterop.Runtime.Injection; 
using System.Collections;
using Il2Cpp;
using UnityEngine.EventSystems;

namespace ModSettings
{
	public class ModSettingsMain : MelonMod
	{
		public override void OnInitializeMelon()
		{
			#if DEBUG
						ModSettingsExample.BasicExample.OnLoad();
						ModSettingsExample.OnChangeExample.OnLoad();
						ModSettingsExample.VisibilityExample.OnLoad();
			#endif
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
            if (sceneName.Contains("MainMenu"))
            {
                Camera eventCam = GameManager.GetMainCamera();

                if (eventCam != null)
                {
                    EventSystem eventSystem = eventCam.gameObject.GetComponent<EventSystem>();

                    if (!eventSystem)
                    {
                        eventSystem = eventCam.gameObject.AddComponent<EventSystem>();
                    }

                    StandaloneInputModule inputModule = eventCam.gameObject.GetComponent<StandaloneInputModule>();

                    if (!inputModule)
                    {
                        eventCam.gameObject.AddComponent<StandaloneInputModule>();
                    }
                }
            }
        }

        public override void OnUpdate()
		{

		}

    }
}