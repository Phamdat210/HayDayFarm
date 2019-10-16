using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaAnimation : MonoBehaviour
{
    SkeletonAnimation sAnim;
    public static GaAnimation instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sAnim = GetComponent<SkeletonAnimation>();
        sAnim.AnimationName = "an";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void An()
    {
        sAnim.AnimationName = "an";
    }

    public void No()
    {
        sAnim.AnimationName = "lo";
    }
}
