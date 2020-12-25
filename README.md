# Unity-NavMesh-load navMeshObstacles for your terrain trees
This is small addon for the unity NavMeshComponents that allows you to load your Terrain trees as actual obstacles into the navMeshSurface.



For the Script to work you have to add Either a CapsuleCollider or a BoxCollider to your tree and ajust it on how big you wana have the NavMeshObstacle Componnent.
If you don't do this, The NavMeshObstacle does not know where to get its value from and the script stops working.

![Tut1](https://user-images.githubusercontent.com/76574483/103113332-89554580-465a-11eb-9d40-5aab74c8db56.png)

Check if all the trees you want to have a NavMeshObstacle for are in your Terrain Tree index.
![Tut2](https://user-images.githubusercontent.com/76574483/103113466-29ab6a00-465b-11eb-8a01-cb0c2ff31be5.png)

Before hitting the play button, Check if navMEshSurface has Baked the Terrain.
then add the Scrip and hit play. (it loads relativly fast on 30k trees). After Loading you should see a gameObject named "Tree_Obstacles".
in there are all the NavMeshObstacle. Done.

![tut3](https://user-images.githubusercontent.com/76574483/103113717-44321300-465c-11eb-9b16-279192ba2392.png)

Link to Script : https://github.com/Malikir324/Unity-NavMesh-adding-Obstacles-To-Terrain-Trees/blob/main/SetTerrainObstacles.cs
