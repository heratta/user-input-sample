using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class UserInputButtonToggle : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        
        [SerializeField] private Text label;

        [SerializeField] private float labelFadeDuration;

        private float _labelFadeTime;

        public void SetOnFlag(bool isOn)
        {
            if (toggle.isOn != isOn)
            {
                _labelFadeTime = 0f;
            }
            
            toggle.isOn = isOn;
        }

        private void Awake()
        {
            SetOnFlag(false);
            _labelFadeTime = labelFadeDuration;
        }

        private void Update()
        {
            _labelFadeTime += Time.deltaTime;
            var colorA = toggle.isOn ? Color.black : Color.red;
            var colorB = toggle.isOn ? Color.red : Color.black;
            var t = Mathf.Min(_labelFadeTime / labelFadeDuration, 1f);
            label.color = Color.Lerp(colorA, colorB, t);
        }
    }
}
