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
* Function       : 此文件附在切割所使用的刀片上 用于切割物体
* 
* Author         : dyi
* Date           : 2020.04.29
* Note           : 此文件为测试待用
* Modify History : 新建文件（2020.02.01-dyi）； 添加切割爆炸效果（2020.04.29）
     
*****************************************************************************************************************/

public class Splitter : MonoBehaviour
{
    public Material matCross;  // 用于接收物体切割后形成的切口所要填充的材质

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");  // 获取鼠标左右方向的移动量  鼠标固定不动时 mx值为0
        transform.Rotate(0, 0, -mx);  // 使鼠标的移动作为切割面的旋转角度

        if (Input.GetMouseButtonDown(0))  // 点击鼠标左键时
        {
            
            // 碰撞检测，投射一个立方体盒子 中心为刀片的中心 用于检测刀片上存在的物体 并将检测到的这些物体存放于colliders数组中  排除layer的名称为Solid的物体（保证地板和刀片本身不被切割）
            Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(4, 0.005f, 4), transform.rotation, ~LayerMask.GetMask("Solid"));

            foreach (Collider c in colliders)
            {  
                // 遍历刀片上获取到的物体
                Destroy(c.gameObject);
                //GameObject[] objs = c.gameObject.SliceInstantiate(transform.position, transform.up);  // 指定刀片的位置和法线方向，SliceInstantiate将物体c切割成两部分,以数组形式返回
                SlicedHull hull = c.gameObject.Slice(transform.position, transform.up);  // 切口处理，
                if (hull != null)
                {
                    // 物体被切开后切口部分没有材质，显示为紫红色，所以需要给切口上材质球
                    GameObject lower = hull.CreateLowerHull(c.gameObject, matCross);  // 物体被切开后的下部分  matCross指定填充的材质  填充到切口上
                    GameObject upper = hull.CreateUpperHull(c.gameObject, matCross);  // 物体被切开后的下部分
                    GameObject[] objs = new GameObject[] { lower, upper };

                    foreach (GameObject obj in objs)  // 遍历所有被切割后新产生的物体
                    {
                        Rigidbody newObj = obj.AddComponent<Rigidbody>();  // 为切割后新产生的物体添加刚体属性
                        obj.AddComponent<MeshCollider>().convex = true;  // 为切割后新产生的物体添加网格碰撞体属性  并勾选convex  否则物体会穿透地板
                        // 注意刀片的碰撞体属性可以删除掉  否则切割完成的物体上半部分会停留在刀片表面掉不下去
                        newObj.AddExplosionForce(100, c.gameObject.transform.position, 20);  // 给切割后的两个物体添加爆炸效果  爆炸力度  爆炸位置  爆炸半径
                    }
                }
            }
        }
    }
}
