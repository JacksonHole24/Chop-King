using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [Header("Tree Pieces")]
    [SerializeField] List<GameObject> middlePieces;
    [SerializeField] List<GameObject> branchRightPieces;
    [SerializeField] List<GameObject> branchLeftPieces;

    [Header("Spawn Odds")]
    [Range(0, 100)]public float branchSpawnChance;
    [Range(0, 1)] public float branchSpawnRamping;
    [SerializeField] public int treesTillSpawnChanceChange;

    private GameManager gameManager;

    [HideInInspector] public int treesDestroyed;
    private int oldTreesDestroyed = 0;

    [HideInInspector] public List<GameObject> treeParts = new List<GameObject>();

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        ReFillList();
    }

    void Update()
    {
        
    }

    public void GetObjToSpawn()
    {
        if (branchSpawnChance < 60)
        {
            if (treesDestroyed > oldTreesDestroyed + treesTillSpawnChanceChange)
            {
                branchSpawnChance += branchSpawnRamping;
            }
        }
        else Debug.Log("Reached Max Spawn Limit");

        int rand = Random.Range(0, 100);
        if(rand < branchSpawnChance)
        {
            int ran = Random.Range(0, 2);
            if(ran  == 0)
            {
                int ran1 = Random.Range(0, branchLeftPieces.Count);
                SpawnTree(branchLeftPieces[ran1]);
            }
            else
            {
                int ran1 = Random.Range(0, branchRightPieces.Count);
                SpawnTree(branchRightPieces[ran1]);
            }
        }
        else
        {
            int ran = Random.Range(0, middlePieces.Count);
            SpawnTree(middlePieces[ran]);
        }
    }

    public void SpawnTree(GameObject obj)
    {
        Debug.Log(treeParts[treeParts.Count - 1]);
        Vector2 spawnPos = new Vector2(treeParts[treeParts.Count-1].transform.position.x, treeParts[treeParts.Count-1].transform.position.y + 200);
        GameObject instantiated = Instantiate(obj, spawnPos, treeParts[treeParts.Count - 1].transform.rotation);
        instantiated.transform.SetParent(gameManager.Tree.transform);
        treeParts.Clear();
        ReFillList();
    }

    public void ReFillList()
    {
        foreach(GameObject treeObj in GameObject.FindGameObjectsWithTag("TreePart"))
        {
            treeParts.Add(treeObj);
        }
    }
}
