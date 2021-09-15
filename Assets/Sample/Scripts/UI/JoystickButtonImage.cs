using UnityEngine;
using UnityEngine.UI;

namespace Sample.UI
{
    public class JoystickButtonImage : MonoBehaviour
    {
        [SerializeField] private string key;
        
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if (Input.GetKey(key))
            {
                _image.color = Color.red;
            }
            else
            {
                _image.color = Color.white;
            }
        }
    }
}
