using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataVatNuoi : ScriptableObject
{
    [System.Serializable]
    public struct VatNuoi
    {
        public int Id;
        public string Name;
        public int GiaTien;
        public string ThuHoach;
        public string Time;
        public int KinhNghiem;
        public int TimeNuoi;
        public int SoLuong;
        public int DonGia;
        public GameObject Obj;
        public Sprite Chuong;
        public Sprite Animal;
        public Sprite Animal2;
        public Sprite Animal3;
        public Sprite Animal4;
        public Sprite ThuHoachDe;
    }

    public VatNuoi[] data;
}
