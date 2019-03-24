using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class RotationSystem : JobComponentSystem
{

    //把业务逻辑包装成为一个结构体，JobComponentSystem中的OnUpdate会并行处理多个业务逻辑实例，所有的包含Rotataion和RotationSpeed都会自动被寻找
    [BurstCompile]
    struct RotationSpeedRotation : IJobProcessComponentData<Rotation, RotationSpeed>
    {
        //间隔时间
        public float deltaTime;

        //必须显示声明Public，否则ECS会无法调用
        //执行方法，并行执行，每帧一次
        public void Execute(ref Rotation rotation, ref RotationSpeed speed)
        {
            //绕纵轴转
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), speed.rotationSpeed * deltaTime));
        }
    }

    //重写onupdate方法
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        RotationSpeedRotation job = new RotationSpeedRotation() { deltaTime = Time.deltaTime };
        return job.Schedule(this, inputDeps);
    }

}
