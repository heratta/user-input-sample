using Helab.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class UserInputAxis : MonoBehaviour
    {
        [SerializeField] private Image cursor;

        [SerializeField] private UserInput userInput;

        [SerializeField] private float radius;

        [SerializeField] private string axisName;

        private void Awake()
        {
            cursor.transform.localPosition = Vector3.zero;
        }

        private void Update()
        {
            SetCursorPosition(userInput.GetAxis(axisName));
        }

        private void SetCursorPosition(Vector2 normalizedPosition)
        {
            cursor.transform.localPosition = normalizedPosition * radius;
        }
    }
}
