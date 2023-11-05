using UnityEngine;
using UnityEngine.UI;

public sealed class ScreenManager : MonoBehaviour
{
    [SerializeField] private Button[] activateButtons;
    [SerializeField] private Camera secondCamera;

    private void Start()
    {
        foreach (var button in activateButtons)
            button.onClick.AddListener(() =>
            {
                if (Display.displays.Length != 1)
                {
                    Display.displays[1].Activate();
                }
                secondCamera.enabled = !secondCamera.enabled;
            });
    }
}