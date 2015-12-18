using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class SphereBehavior : MonoBehaviour
    {
        public Text CountText;

        private int _ballsCollided;

        void Start()
        {
            Physics.gravity = new Vector3(0, -98f, 0);

            _ballsCollided = 0;
            CountText.text = "Collides: " + _ballsCollided;
        }
        
        void OnTriggerEnter(Component other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            _ballsCollided++;
            CountText.text = "Collides: " + _ballsCollided;
        }
    }
}
