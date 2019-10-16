using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTool : ScriptableObject
{
    [System.Serializable]
    public struct Tool
    {
        public int Id;
        public string Name;
        public int GiaTien;
        public string Content;
        public int SoLuong;
        public Sprite Img;
        public GameObject obj;
    }
    
    public Tool[] data;
}