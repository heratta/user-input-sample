using System.Collections.Generic;
using UnityEngine;

namespace Helab.Input
{
    public class UserInput : MonoBehaviour
    {
        private readonly Dictionary<string, UserInputAxisBinder> _axisBinders = new Dictionary<string, UserInputAxisBinder>();
        
        private readonly Dictionary<string, UserInputButtonBinder> _buttonBinders = new Dictionary<string, UserInputButtonBinder>();

        private void Awake()
        {
            var axisBinders = GetComponentsInChildren<UserInputAxisBinder>();
            foreach (var binder in axisBinders)
            {
                if (!_axisBinders.ContainsKey(binder.inputName))
                {
                    _axisBinders.Add(binder.inputName, binder);
                }
            }
            
            var buttonBinders = GetComponentsInChildren<UserInputButtonBinder>();
            foreach (var binder in buttonBinders)
            {
                if (!_buttonBinders.ContainsKey(binder.inputName))
                {
                    _buttonBinders.Add(binder.inputName, binder);
                }
            }
        }

        public Vector2 GetAxis(string inputName)
        {
            var result = Vector2.zero;
            if (_axisBinders.TryGetValue(inputName, out var binder))
            {
                result = binder.axisValue;
            }

            return result;
        }

        public bool GetButton(string inputName)
        {
            var result = false;
            if (_buttonBinders.TryGetValue(inputName, out var binder))
            {
                result = binder.buttonValue;
            }

            return result;
        }

        public bool GetButtonDown(string inputName)
        {
            var result = false;
            if (_buttonBinders.TryGetValue(inputName, out var binder))
            {
                result = binder.buttonDownValue;
            }

            return result;
        }

        public bool GetButtonRepeat(string inputName)
        {
            var result = false;
            if (_buttonBinders.TryGetValue(inputName, out var binder))
            {
                result = binder.buttonRepeatValue;
            }

            return result;
        }
    }
}
