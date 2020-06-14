using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModelViewer : MonoBehaviour
{
    [SerializeField] private ModelController _modelController = null;
    [SerializeField] private Canvas _ui = null;

    private List<GameObject> _models = new List<GameObject>();
    private int _currentModel = 0;
    private string _outputPath = string.Empty;
    private WaitForEndOfFrame _wait = new WaitForEndOfFrame();

    private void Start()
    {
        _outputPath = Application.dataPath + "/Output";
    }

    /// <summary>
    /// Sets list of loaded models
    /// </summary>
    /// <param name="models">List of models' GameObjects on scene</param>
    public void SetModels( List<GameObject> models )
    {
        _models = models;
        if ( _models.Count != 0 )
        {
            ShowModel( _models[ 0 ] );
        }
    }

    /// <summary>
    /// Shows next model if available and hides current
    /// </summary>
    public void ShowNextModel()
    {
        if ( _currentModel + 1 < _models.Count )
        {
            _models[ _currentModel ].SetActive( false );

            _currentModel++;

            ShowModel( _models[ _currentModel ] );
        }
    }

    /// <summary>
    /// Shows previous model if available and hides current
    /// </summary>
    public void ShowPreviousModel()
    {
        if ( _currentModel - 1 >= 0 && _models.Count != 0 )
        {
            _models[ _currentModel ].SetActive( false );

            _currentModel--;

            ShowModel( _models[ _currentModel ] );
        }
    }

    /// <summary>
    /// Function for button to run coroutine to take photo
    /// </summary>
    public void TakePhoto()
    {
        if ( !Directory.Exists( _outputPath ) )
        {
            Directory.CreateDirectory( _outputPath );
        }

        StartCoroutine( CaptureScreen() );
    }

    /// <summary>
    /// Takes photo without ui
    /// </summary>
    private IEnumerator CaptureScreen()
    {
        _ui.enabled = false;

        yield return null;

        DateTime dateTime = DateTime.Now;
        ScreenCapture.CaptureScreenshot( _outputPath + $"/{_models[ _currentModel ].name}_{dateTime:yyMMddHHmmss}.png" );

        yield return _wait;

        _ui.enabled = true;
    }

    /// <summary>
    /// Resets and shows given model on scene
    /// </summary>
    /// <param name="model">Model to show</param>
    private void ShowModel( GameObject model )
    {
        model.transform.SetPositionAndRotation( Vector3.zero, Quaternion.identity );
        model.SetActive( true );
        _modelController.SetCurrentModel( model.transform );
    }
}
