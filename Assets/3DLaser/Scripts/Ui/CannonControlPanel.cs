using _3DLaser.Scripts.LaserCannon;
using UnityEngine;

namespace _3DLaser.Scripts.Ui
{
    public class CannonControlPanel : MonoBehaviour
    {
        [SerializeField] private CannonController _cannonController;

        private bool _isLeftButtonPressed;
        private bool _isRightButtonPressed;
        private bool _isUpButtonPressed;
        private bool _isDownButtonPressed;
    
        private void Update()
        {
            if (_isLeftButtonPressed)
            {
                _cannonController.TurnPlatformLeft();
            }
            else if (_isRightButtonPressed)
            {
                _cannonController.TurnPlatformRight();
            }
            else if (_isUpButtonPressed)
            {
                _cannonController.TiltBarrelUp();
            }
            else if (_isDownButtonPressed)
            {
                _cannonController.TiltBarrelDown();
            }
        }
    
        public void OnLeftButtonPress(bool isPressed)
        {
            _isLeftButtonPressed = isPressed;
        }
    
        public void OnRightButtonPress(bool isPressed)
        {
            _isRightButtonPressed = isPressed;
        }
    
        public void OnUpButtonPress(bool isPressed)
        {
            _isUpButtonPressed = isPressed;
        }
    
        public void OnDownButtonPress(bool isPressed)
        {
            _isDownButtonPressed = isPressed;
        }
    }
}