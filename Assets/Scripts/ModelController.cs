using UnityEngine;

public class ModelController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0.5f;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _zoomSpeed = 0.5f;

    private Transform _currentModel = null;
    private Vector2 _previousCursorPos = Vector2.zero;
    private Vector2 _currentCursorPos = Vector2.zero;
    
    /// <summary>
    /// Sets current model to control
    /// </summary>
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
            Move( posChange );
        }
        else if ( Input.GetMouseButton( 1 ) )
        {
            if ( Input.GetKey( KeyCode.LeftAlt ) )
            {
                Zoom( posChange.y );
            }
            else
            {
                Rotate( posChange );
            }
        }

        _previousCursorPos = _currentCursorPos;
    }

    /// <summary>
    /// Moves model in x y coordinates
    /// </summary>
    /// <param name="posChange">Unscaled position change</param>
    private void Move( Vector2 posChange )
    {
        _currentModel.Translate( posChange * _movementSpeed * Time.deltaTime, Space.World );
    }

    /// <summary>
    /// Zooms model in or out
    /// </summary>
    /// <param name="zoomValue">Positive value zooms in - negative zooms out</param>
    private void Zoom( float zoomValue )
    {
        _currentModel.Translate( new Vector3( 0f, 0f, zoomValue * _zoomSpeed * Time.deltaTime ), Space.World );
    }

    /// <summary>
    /// Rotates model about x and y axis
    /// </summary>
    /// <param name="mousePosChange">Original mouse position change</param>
    private void Rotate( Vector2 mousePosChange )
    {
        _currentModel.Rotate( new Vector3( mousePosChange.y, -mousePosChange.x, 0f ) * _rotationSpeed * Time.deltaTime, Space.World );
    }
}
