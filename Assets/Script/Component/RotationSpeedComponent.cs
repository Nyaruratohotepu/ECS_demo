using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

//旋转速度
[System.Serializable]
public struct RotationSpeed : IComponentData
{
    public float rotationSpeed;
}
//封装成组件
public class RotationSpeedComponent : ComponentDataWrapper<RotationSpeed>
{

}