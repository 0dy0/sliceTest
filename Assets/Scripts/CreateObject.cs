using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
* Date           : 2020.04.29
* Note           : 此文件为测试待用
* Modify History : 新建文件（2020.03.28）
     
*****************************************************************************************************************/

public class CreateObject : MonoBehaviour
{
    public List<GameObject> prefabes;  // 用于接收将要新产生的预制体

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // 点击鼠标右键时
        {
            GameObject prefabe = prefabes[Random.Range(0,prefabes.Count - 1)];  // 从预制体列表prefabes中随机抽取一个预制体出来
            GameObject newPrefabe = Instantiate(prefabe,transform.position,transform.rotation);  // 在场景中实例化创建这个预制体,在当前物体的位置产生，朝向为当前物体的朝向

            // Rigidbody rigid = prefabe.AddComponent<Rigidbody>();  // 给预制体添加刚体属性
            Rigidbody rigid = newPrefabe.AddComponent<Rigidbody>();  // 给界面上新产生的预制体添加刚体属性，方便后面切割操作
            rigid.AddForce(Vector3.up * 500);  // 将产生的物体向世界坐标上方加力扔出
        }
    }
}
