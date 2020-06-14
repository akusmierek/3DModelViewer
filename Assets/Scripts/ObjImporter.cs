using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Dummiesman;

public class ObjImporter : MonoBehaviour
{
    [SerializeField] private ModelViewer _modelViewer = null;


    private void Start()
    {
        var files = GetFiles();

        LoadModels( files );
    }

    private List<string> GetFiles()
    {
        List<string> fileList = new List<string>();

        try
        {
            var files = Directory.GetFiles( Application.dataPath + "/Input", "*.obj", SearchOption.AllDirectories );

            foreach ( var file in files )
            {
                fileList.Add( file );
            }

            return fileList;
        }
        catch ( Exception e )
        {
            Debug.Log( e.Message );
        }

        return fileList;
    }

    private void LoadModels( List<string> files )
    {
        var loadedModels = new List<GameObject>();

        foreach ( var file in files )
        {
            GameObject loadedModel = new OBJLoader().Load( file );
            loadedModel.SetActive( false );
            loadedModels.Add( loadedModel );
        }

        _modelViewer.SetModels( loadedModels );
    }
}
