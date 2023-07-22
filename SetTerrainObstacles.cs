using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetTerrainObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    TreeInstance[] Obstacle;
    Terrain terrain;
    float width;
    float lenght; 
    float hight;
    bool isError;
    void Start()
    {
        terrain = Terrain.activeTerrain;
        Obstacle = terrain.terrainData.treeInstances;

        lenght = terrain.terrainData.size.z;
        width = terrain.terrainData.size.x;
        hight = terrain.terrainData.size.y;
        Debug.Log("Terrain Size is :" + width + " , " + hight + " , " + lenght);

        int i = 0;
        GameObject parent = new GameObject("Tree_Obstacles");

        Debug.Log("Adding "+Obstacle.Length+" navMeshObstacle Components for Trees");
        foreach (TreeInstance tree in Obstacle)
        {
            Vector3 tempPos = new Vector3(tree.position.x * width, tree.position.y * hight, tree.position.z * lenght);
            Quaternion tempRot = Quaternion.AngleAxis(tree.rotation * Mathf.Rad2Deg, Vector3.up);

            GameObject obs = new GameObject("Obstacle" + i);
            obs.transform.SetParent(parent.transform);
            obs.transform.position = tempPos;
            obs.transform.rotation = tempRot;

            obs.AddComponent<NavMeshObstacle>();
            NavMeshObstacle obsElement = obs.GetComponent<NavMeshObstacle>();
            obsElement.carving = true;
            obsElement.carveOnlyStationary = true;

            if (terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<Collider>() == null)
            {
                isError = true;
                Debug.LogError("ERROR  There is no CapsuleCollider or BoxCollider attached to ''" + terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.name + "'' please add one of them.");
                break;
            }
            Collider coll = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<Collider>();
            if(coll.GetType() == typeof(CapsuleCollider) || coll.GetType() == typeof(BoxCollider))
            {

                if (coll.GetType() == typeof(CapsuleCollider))
                {
                    CapsuleCollider capsuleColl = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<CapsuleCollider>();
                    obsElement.shape = NavMeshObstacleShape.Capsule;
                    obsElement.center = capsuleColl.center;
                    obsElement.radius = capsuleColl.radius;
                    obsElement.height = capsuleColl.height;
                                      
                }
                else if (coll.GetType() == typeof(BoxCollider))
                {
                    BoxCollider boxColl = terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.GetComponent<BoxCollider>();
                    obsElement.shape = NavMeshObstacleShape.Box;
                    obsElement.center = boxColl.center;
                    obsElement.size = boxColl.size;
                }
               
            }
            else 
            {
                isError = true;
                Debug.LogError("ERROR  There is no CapsuleCollider or BoxCollider attached to ''" + terrain.terrainData.treePrototypes[tree.prototypeIndex].prefab.name + "'' please add one of them.");
                break;
            }


            i++;
        }
        parent.transform.position = terrain.GetPosition();
        if(!isError) Debug.Log("All " + Obstacle.Length + " NavMeshObstacles were succesfully added to your Scene, Horray !");
    }
}
