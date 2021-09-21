using UnityEngine;

namespace Helab.Input
{
    public class UserInputAxisBinder : MonoBehaviour
    {
        public string inputName;

        [SerializeField] private string xAxisName;
        
        [SerializeField] private string yAxisName;
        
        [SerializeField] private KeyCode xAxisUpKey;
        
        [SerializeField] private KeyCode xAxisDownKey;
        
        [SerializeField] private KeyCode yAxisUpKey;
        
        [SerializeField] private KeyCode yAxisDownKey;
        
        [SerializeField] private float validThresholdsForJoystick = 0.1f;

        public Vector2 axisValue;

        private void Update()
        {
            axisValue.x = GetAxis(xAxisName, xAxisUpKey, xAxisDownKey);
            axisValue.y = GetAxis(yAxisName, yAxisUpKey, yAxisDownKey);
            
            if (1f < axisValue.magnitude)
            {
                axisValue.Normalize();
            }
        }

        private float GetAxis(string axisName, KeyCode upKey, KeyCode downKey)
        {
            var result = 0f;
            
            if (!string.IsNullOrEmpty(axisName))
            {
                var axis = UnityEngine.Input.GetAxis(axisName);
                if (validThresholdsForJoystick < Mathf.Abs(axis))
                {
                    result += axis;
                }
            }

            if (UnityEngine.Input.GetKey(upKey))
            {
                result += 1f;
            }

            if (UnityEngine.Input.GetKey(downKey))
            {
                result += -1f;
            }

            return result;
        }
    }
}
