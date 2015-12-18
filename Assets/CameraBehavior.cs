using UnityEngine;

namespace Assets
{
    public class CameraBehavior : MonoBehaviour
    {
        private const float InfiniteSmall = 0.0001f;
        private const float RotationStep = 5;

        public GameObject Player;
        public float ForceDefault;

        private Vector3 _offset;
        private Rigidbody _playeRigidbody;

        void Start ()
        {
            _offset = transform.position - Player.transform.position;
            _playeRigidbody = Player.GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.RotateAround(Player.transform.position, Vector3.up, -RotationStep);
            else if (Input.GetKey(KeyCode.RightArrow))
                transform.RotateAround(Player.transform.position, Vector3.up, RotationStep);

            _offset = transform.position - Player.transform.position;

            var forceValue = 0.0f;
            if (Input.GetKey(KeyCode.UpArrow))
                forceValue = -ForceDefault;
            else if (Input.GetKey(KeyCode.DownArrow))
                forceValue = ForceDefault;

            if (Mathf.Abs(forceValue) < InfiniteSmall)
                return;
            
            var direction = new Vector3(_offset.x, 0, _offset.z);
            direction.Normalize();
            _playeRigidbody.AddForce(forceValue * direction);
        }

        void LateUpdate ()
        {
            transform.position = Player.transform.position + _offset;
        }
    }
}
