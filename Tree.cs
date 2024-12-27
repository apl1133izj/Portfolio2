using UnityEngine;

public class Tree : MonoBehaviour
{
    SpriteRenderer treesSriteRenderer;
    public Sprite cuttingTreeSprite;
    public Animator treeAnimator;
    public LayerMask layerMask;
    int cuttingIntMax = 30;

    public int cuttingInt;
    public bool treeHitBool;//������ ���� �ִ���
    public float resetTreeTime;
    bool treeReSetBool;
    public float overlapCheckRadius = 6f; // ������Ʈ ���� �ּ� �Ÿ�
    float timeCutting;
    bool warkerOn;
    private void Awake()
    {
        treeAnimator = GetComponent<Animator>();
        treesSriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        ResetTree();
        if (warkerOn && cuttingInt == 0)
        {
            timeCutting += Time.deltaTime;
        }
        else
        {
            timeCutting = 0;
        }
    }
    private void ResetTree()
    {

        if (cuttingInt == 31)
        {
            treeReSetBool = true;
            cuttingInt = 0;
        }
        if (treeReSetBool)
        {
            resetTreeTime += Time.deltaTime;
            if (resetTreeTime >= 200f)
            {
                treeAnimator.enabled = true;
                gameObject.tag = "Tree";
                resetTreeTime = 0;
                treeReSetBool = false;

            }
        }
    }
    Vector3 GetNonOverlappingPosition()
    {
        Vector3 spawnPosition;

        do
        {
            // ������ ��ġ�� �����ϰų� Ư���� �������� ��ġ�� �����մϴ�.
            spawnPosition = new Vector2(transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f));
        }
        while (CheckOverlap(spawnPosition));

        return spawnPosition;
    }

    bool CheckOverlap(Vector3 position)
    {
        // ���ο� ��ġ �ֺ��� �ٸ� ������Ʈ�� �ִ��� üũ
        Collider[] colliders = Physics.OverlapSphere(position, overlapCheckRadius);

        // �ٸ� Collider�� �����ϸ� ��ġ�� ������ ����
        return colliders.Length > 0;
    }
    public GameObject woodeInstGameObject;
    void InstantiatePrefab(Vector3 position)
    {
        if (cuttingInt % 6 == 0)
        {
            // ��ġ�� Prefab�� ����
            Instantiate(woodeInstGameObject, position, Quaternion.identity);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Warker warker = collision.gameObject.GetComponent<Warker>();
        if (collision.gameObject.CompareTag("Warker"))
        {
            warkerOn = true;
            if (cuttingInt == cuttingIntMax)
            {
                warker.GetComponent<Collider2D>().enabled = false;
                treeAnimator.enabled = false;
                treesSriteRenderer.sprite = cuttingTreeSprite;
                treeHitBool = false;
                cuttingInt = 0;
                warker.warkerActionsBool = false;
                gameObject.tag = "CuttingTree";
                Debug.Log("���� ���� �Ϸ�");
            }

            
            if (timeCutting >= 0.95f || cuttingInt >= 1)
            {
                treeAnimator.SetTrigger("TreeHitTrigger");
                Vector3 spawnPosition = GetNonOverlappingPosition();
                InstantiatePrefab(spawnPosition);
                warkerOn = false;
                cuttingInt += 1;
                treeHitBool = true;
            }
        }
    }
}
