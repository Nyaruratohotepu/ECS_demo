# ECS_demo
本案例测试ECS架构和普通架构的性能差距
项目中的两个场景分别通过传统写法和使用ECS架构实现50000个立方体旋转
在本人的环境中，运行速率分别是3帧和27帧，可以看出ECS架构在极端条件下能远远领先传统架构
传统架构中，每个GameObject包含一个旋转自身的脚本
ECS框架中使用到了burst和job system，可以进行多线程处理
参考文档：
https://blog.csdn.net/yye4520/article/details/82217247
https://blog.csdn.net/yye4520/article/details/82804179