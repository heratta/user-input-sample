using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class JoystickAxisSlider : MonoBehaviour
    {
        [SerializeField] private string axisName;

        [SerializeField] private Slider slider;
        
        [SerializeField] private Text valueText;

        private void Update()
        {
            var axisValue = Input.GetAxis(axisName);
            valueText.text = $"{axisValue:F}";
            slider.value = (axisValue + 1f) * 0.5f;
        }
    }
}
