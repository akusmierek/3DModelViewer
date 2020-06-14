﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModelViewer : MonoBehaviour
{
    [SerializeField] private ModelController _modelController = null;

    private List<GameObject> _models = new List<GameObject>();
    private int _currentModel = 0;
    private string _outputPath = string.Empty;

    private void Start()
    {
        _outputPath = Application.dataPath + "/Output";
    }

    public void SetModels( List<GameObject> models )
    {
        _models = models;
        if ( _models.Count != 0 )
        {
            ShowModel( _models[ 0 ] );
        }
    }

    public void ShowNextModel()
    {
        if ( _currentModel + 1 < _models.Count )
        {
            _models[ _currentModel ].SetActive( false );

            _currentModel++;

            ShowModel( _models[ _currentModel ] );
        }
    }

    public void ShowPreviousModel()
    {
        if ( _currentModel - 1 >= 0 && _models.Count != 0 )
        {
            _models[ _currentModel ].SetActive( false );

            _currentModel--;

            ShowModel( _models[ _currentModel ] );
        }
    }

    public void TakePhoto()
    {
        if ( !Directory.Exists( _outputPath ) )
        {
            Directory.CreateDirectory( _outputPath );
        }

        DateTime dateTime = DateTime.Now;
        ScreenCapture.CaptureScreenshot( _outputPath + $"/{_models[ _currentModel ].name}_{dateTime:yyMMddHHmmss}.png" );
    }

    private void ShowModel( GameObject model )
    {
        model.transform.SetPositionAndRotation( Vector3.zero, Quaternion.identity );
        model.SetActive( true );
        _modelController.SetCurrentModel( model.transform );
    }
}
