using Helab.Input;
using UnityEngine;

namespace Sample.UI
{
    public class UserInputButton : MonoBehaviour
    {
        [SerializeField] private UserInput userInput;

        [SerializeField] private string inputName;
        
        [SerializeField] private UserInputButtonToggle getToggle;
        
        [SerializeField] private UserInputButtonToggle getDownToggle;
        
        [SerializeField] private UserInputButtonToggle repeatToggle;

        private void Update()
        {
            getToggle.SetOnFlag(userInput.GetButton(inputName));
            getDownToggle.SetOnFlag(userInput.GetButtonDown(inputName));
            repeatToggle.SetOnFlag(userInput.GetButtonRepeat(inputName));
        }
    }
}
