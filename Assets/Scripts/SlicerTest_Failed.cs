using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

/***************************************************************************************************************

                                             VR Fishing Project
                                                 2019-2020
                              Copyright (C) 2020, 安徽大学虚拟创客实验平台 VR编程组
                                            All Rights Reserved.


================================================================================================================

* Module Name    : CreateObject.cs
* Function       : 此文件附在切割所使用的刀片上 产生新的待切割的物体
* 
* Author         : dyi
* Date           : 2020.02.19
* Note           : 此文件为测试待用
* Modify History : 新建文件（2020.01.23-dyi）；废弃该文件（2020.02.19-dyi）
     
*****************************************************************************************************************/

public class SlicerTest_Failed : MonoBehaviour
{
    public GameObject source;  // 要切割的物体
    //public GameObject source1;  // 要切割的物体


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            SlicedHull hull = source.Slice(transform.position, transform.up);  // 参数一为切割的位置（刀片的位置），第二个参数为切割面的法向量
            hull.CreateUpperHull(source);  // 创建把source切割以后的上半部分物体
            hull.CreateLowerHull(source);  // 下半部分物体
            source.SetActive(false);  // 销毁原物体

            //SlicedHull hull1 = source1.Slice(transform.position, transform.up);  // 参数一为切割的位置（刀片的位置），第二个参数为切割面的法向量
            //hull1.CreateUpperHull(source1);  // 创建把source1切割以后的上半部分物体
            //hull1.CreateLowerHull(source1);  // 下半部分物体
            //source1.SetActive(false);  // 销毁原物体
        }   
    }
}
