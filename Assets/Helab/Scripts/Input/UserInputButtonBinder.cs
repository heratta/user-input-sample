using UnityEngine;

namespace Helab.Input
{
    public class UserInputButtonBinder : MonoBehaviour
    {
        public string inputName;

        [SerializeField] private string buttonName;
        
        [SerializeField] private KeyCode buttonKey;

        public bool buttonValue;

        public bool buttonDownValue;
        
        public bool buttonRepeatValue;

        public float repeatStartInterval;
        
        public float repeatInterval;
        
        private float _lastRepeatTime;

        private int _repeatCount;

        private void Update()
        {
            buttonValue = UnityEngine.Input.GetButton(buttonName) || UnityEngine.Input.GetKey(buttonKey);
            buttonDownValue = UnityEngine.Input.GetButtonDown(buttonName) || UnityEngine.Input.GetKeyDown(buttonKey);
            UpdateRepeat();
        }

        private void UpdateRepeat()
        {
            var interval = _repeatCount == 1 ? repeatStartInterval : repeatInterval;
            buttonRepeatValue = buttonValue && interval <= UnityEngine.Time.realtimeSinceStartup - _lastRepeatTime;
            
            if (buttonRepeatValue)
            {
                _lastRepeatTime = UnityEngine.Time.realtimeSinceStartup;
                _repeatCount++;
            }
            
            if (!buttonValue)
            {
                _lastRepeatTime = 0f;
                _repeatCount = 0;
            }
        }
    }
}
