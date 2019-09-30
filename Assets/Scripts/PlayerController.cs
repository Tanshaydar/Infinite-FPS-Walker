using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly float HORIZONTAL_OFFSET = 1.15f;

    private CharacterController _controller;
    private Vector3 _velocity;
    private float _verticalSpeed = 5.0f;
    private float _horizontalSpeed = 30.0f;

    private float _verticalInput;
    private float _horizontalInput;
    private LANE _selectedLane = LANE.CENTER;
    private DIRECTION _selectedDirection;
    private Vector3 _horizontalTargetPosition;

    // Game State related
    private bool isPaused;
    private bool hasStarted;
    
    enum LANE
    {
        LEFT,
        CENTER,
        RIGHT
    }

    enum DIRECTION
    {
        NONE,
        RIGHT,
        LEFT
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!hasStarted)
        {
            return;
        }

        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        // Change player speed depending on the input

        if (Mathf.Abs(_verticalInput) > 0)
        {
            if (_verticalInput < 0)
            {
                _verticalSpeed = 3.5f;
            }
            else if (_verticalInput > 0)
            {
                _verticalSpeed = 7.5f;
            }
        }
        else
        {
            _verticalSpeed = 5.0f;
        }

        // Change player lane depending on the input

        if (Mathf.Abs(_horizontalInput) > 0)
        {
            if (_horizontalInput < 0)
            {
                _selectedDirection = DIRECTION.LEFT;
            }
            else if (_horizontalInput > 0)
            {
                _selectedDirection = DIRECTION.RIGHT;
            }
        }
        else
        {
            _selectedDirection = DIRECTION.NONE;
        }


        // Switch player lane
        _horizontalTargetPosition = transform.position.z * Vector3.forward;
        switch (_selectedDirection)
        {
            case DIRECTION.LEFT:
                _horizontalTargetPosition += Vector3.left * HORIZONTAL_OFFSET;
                break;
            case DIRECTION.RIGHT:
                _horizontalTargetPosition += Vector3.right * HORIZONTAL_OFFSET;
                break;
        }

        _velocity.x = (_horizontalTargetPosition - transform.position).normalized.x * _horizontalSpeed;
        _velocity.y = 0;
        _velocity.z = _verticalSpeed;

        _controller.Move(_velocity * Time.deltaTime);
    }

    public void StartMoving()
    {
        hasStarted = true;
    }

    public void Die()
    {
        hasStarted = false;
    }
}