using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCay : ScriptableObject
{
    [System.Serializable]
    public struct Cay
    {
        public int Id;
        public string Name;
        public Sprite Img1;
        public Sprite Img2;
        public Sprite Img3;
        public Sprite Seed;
        public Sprite SeedLock;
        public int DonGia;
        public int TimeCreate;
        public int GiaTien;
        public int KinhNghiem;
        public string Time;
        public string Sp;
        public int LvUnLock;
        public int SoLuong;
        public GameObject obj;
    }

    public Cay[] data;
}
