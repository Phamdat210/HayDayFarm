using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DataEditor  {

   

    [MenuItem("Data/Data/VatNuoi")]
    public static void DetailVatNuoi()
    {
        DataVatNuoi vatnuoi = ScriptableObject.CreateInstance<DataVatNuoi>();
        AssetDatabase.CreateAsset(vatnuoi, "Assets/Data/VatNuoi.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = vatnuoi;

    }

    [MenuItem("Data/Data/Cay")]
    public static void DetailCay()
    {
        DataCay cay = ScriptableObject.CreateInstance<DataCay>();
        AssetDatabase.CreateAsset(cay, "Assets/Data/Cay.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = cay;

    }

    [MenuItem("Data/Data/Tool")]
    public static void DetailMuaHang()
    {
        DataTool muaHang = ScriptableObject.CreateInstance<DataTool>();
        AssetDatabase.CreateAsset(muaHang, "Assets/Data/Tool.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = muaHang;

    }

    [MenuItem("Data/Data/NhaChinh")]
    public static void DetailNhaChinh()
    {
        DataNhaChinh nhaChinh = ScriptableObject.CreateInstance<DataNhaChinh>();
        AssetDatabase.CreateAsset(nhaChinh, "Assets/Data/NhaChinh.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = nhaChinh;

    }
}
