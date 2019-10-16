using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataNhaChinh : ScriptableObject
{
    [System.Serializable]
    public struct NhaChinh
    {
        public int Id;
        public Sprite Img1;
        public Sprite Img2;
        public Sprite Img3;
        
    }

    public NhaChinh[] data;
}
