using UnityEditor;
using UnityEngine;
using System.IO;

[CustomEditor(typeof(AsteroidSpawner))]
public class AsteroidSpawnerEditor : Editor
{
    string path;
    string assetPath;
    string filename;

    private void OnEnable()
    {
        path = Application.dataPath + "/Asteroid"; //Datapath get the path of the project
        assetPath = "Assets/Asteroid/";
        filename = "asteroid_" + System.DateTime.Now.Ticks.ToString(); //get a nice number to the asteroid

    }

    public override void OnInspectorGUI()
    {
        AsteroidSpawner astSpawner = (AsteroidSpawner)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Create Asteroid")) {
            astSpawner.CreateAsteroid();
        }

        if (GUILayout.Button("Save Asteroid")) {
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = astSpawner.asteroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetPath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();

            PrefabUtility.SaveAsPrefabAsset(astSpawner.asteroid, assetPath + filename + ".prefab");
        }
    }
}
