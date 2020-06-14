using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using Dummiesman;

public class ObjImporter : MonoBehaviour
{
    private void Start()
    {
        var files = GetFiles();

        LoadObjects( files );
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

    private void LoadObjects( List<string> files )
    {
        foreach ( var file in files )
        {
            GameObject loadedObj = new OBJLoader().Load( file );
            loadedObj.SetActive( false );
        }
    }
}
