using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

//引导脚本
public class Main : MonoBehaviour {
    public EntityManager entityManager;
    public EntityArchetype entityArchetype;

    public int prefabCount;
    public GameObject perfab;
    public Mesh perfabMesh;
    public Material perfabMaterial;

	// Use this for initialization
	void Start () {
        //初始化EntityManager
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        //Position和Rotation系统自带
        entityArchetype = entityManager.CreateArchetype(typeof(Position), typeof(Rotation), typeof(RotationSpeed));
        if (perfab)
        {
            for(int i = 0; i < prefabCount; i++)
            {
                //创建实体，实体包含的组件由上文的entityArchetype给出
                Entity entity = entityManager.CreateEntity(entityArchetype);

                //设置数值
                //设置位置，调用Unity内置的随机分布函数
                entityManager.SetComponentData(entity, new Position { Value = UnityEngine.Random.insideUnitSphere * 100 });
                //Quaternion.identity就是指Quaternion(0,0,0,0)
                entityManager.SetComponentData(entity, new Rotation { Value = Quaternion.identity });
                entityManager.SetComponentData(entity, new RotationSpeed { rotationSpeed = 100 });

                //设置公共的渲染器
                entityManager.AddSharedComponentData(entity, new MeshInstanceRenderer
                {
                    mesh = perfabMesh,
                    material = perfabMaterial
                });
            }
        }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
