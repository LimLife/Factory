using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotationCamera;
    [SerializeField] private FixedJoystick _move;
    [SerializeField] private FixedJoystick _cameraRotate;
    [SerializeField] private Camera _camera;

    private void Move()
    {
        Vector3 movement = new Vector3(_move.Horizontal, 0.0f, _move.Vertical);
        transform.Translate(_speed * Time.deltaTime * movement);
    }
    private void RotateCamera()
    {
        Vector3 pos = new Vector3(0,_cameraRotate.Horizontal);
        _camera.transform.Rotate(_speedRotationCamera * Time.deltaTime * pos,Space.World); 
    }
    void Update()
    {

        RotateCamera();
        Move();
    }

}
