using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0.5f;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _zoomSpeed = 0.5f;

    private Transform _currentModel = null;
    private Vector2 _previousCursorPos = Vector2.zero;
    private Vector2 _currentCursorPos = Vector2.zero;
    
    public void SetCurrentModel( Transform model )
    {
        _currentModel = model;
    }

    private void Update()
    {
        if ( _currentModel == null )
            return;

        _currentCursorPos = Input.mousePosition;
        Vector2 posChange = _currentCursorPos - _previousCursorPos;

        if ( Input.GetMouseButton( 0 ) )
        {
            _currentModel.Translate( posChange * _movementSpeed * Time.deltaTime, Space.World );
        }
        else if ( Input.GetMouseButton( 1 ) )
        {
            if ( Input.GetKey( KeyCode.LeftAlt ) )
            {
                _currentModel.Translate( new Vector3( 0f, 0f, posChange.y * _zoomSpeed * Time.deltaTime ), Space.World );
            }
            else
            {
                _currentModel.Rotate( new Vector3( posChange.y, -posChange.x, 0f) * _rotationSpeed * Time.deltaTime, Space.World );
            }
        }

        _previousCursorPos = _currentCursorPos;
    }
}
