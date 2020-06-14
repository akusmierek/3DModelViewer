using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelViewer : MonoBehaviour
{
    private List<GameObject> _models = new List<GameObject>();
    private int _currentModel = 0;

    public void SetModels( List<GameObject> models )
    {
        _models = models;
        if ( _models.Count != 0 )
        {
            _models[ 0 ].SetActive( true );
        }
    }

    public void ShowNextModel()
    {
        if ( _currentModel + 1 < _models.Count )
        {
            _models[ _currentModel ].SetActive( false );
            _currentModel++;
            _models[ _currentModel ].SetActive( true );
        }
    }

    public void ShowPreviousModel()
    {
        if ( _currentModel - 1 >= 0 && _models.Count != 0 )
        {
            _models[ _currentModel ].SetActive( false );
            _currentModel--;
            _models[ _currentModel ].SetActive( true );
        }
    }

    public void TakePhoto()
    {
        // TODO
    }
}
