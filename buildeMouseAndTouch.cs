using UnityEngine;
public class buildeMouseAndTouch : MonoBehaviour
{
    public enum BuildKind { Null, BuildHouse, BuildMine, BuildTower, Feed, Slaughter, False }
    public BuildKind buildKind;
    public Camera camera;
    public Vector2 mousePosition;
    Vector3 worldMousePosition;
    public bool buildStart;
    public bool buildEnd;
    public bool buildWarkerInstBool;
    public bool buildGread;
    public GameObject[] buildPrefab;
    public CuserKind mouseCuser;
    public bool buildGroundBool;
    GameManager gameManager;

    public GameObject xp;
    

    private void Awake()
    {
        gameManager = FindObjectOfType <GameManager>();
        mouseCuser = FindObjectOfType<CuserKind>();     
    }
    private void Start()
    {
        buildKind = BuildKind.Null;

    }
    void Update()
    {
        MouseEvent();

        HandleTouchBegin();
    }

    void HandleTouchBegin()
    {

        Camera mainCamera = Camera.main; // 씬 전환 후에도 올바른 카메라 참조를 위해
        if (mainCamera != null)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseCuser.transform.position = mousePosition - new Vector2(-0.1f, 0.28f);
        }
        else
        {
            Debug.LogWarning("Main camera not found in the scene.");
        }
    }

    void MouseEvent()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (buildKind == BuildKind.BuildHouse)
            {
                buildEnd = true;
            }
            else if (buildKind == BuildKind.BuildMine)
            {
                buildEnd = true;
            }
            else if (buildKind == BuildKind.BuildTower)
            {
                buildEnd = true;
            }
            else if(buildKind == BuildKind.Feed)
            {
                buildEnd = true;
            }

        }
        else if (Input.GetMouseButtonUp(0) && buildEnd)
        {
            if (buildGread)//다른 건물이 없는가 확인
            {
                Vector2 mousePosition = Input.mousePosition;//마우스 위치 저장
                //화면의 마우스 위치를 월드 공간으로 변환
                Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                
                if (buildKind == BuildKind.BuildHouse)//워커 집 짓기
                {
                    buildWarkerInstBool = true;
                    GameObject xpGameObject = Instantiate(xp, transform.position, Quaternion.identity);
                    GameObject warkerGameObject = Instantiate(buildPrefab[0], worldMousePosition, Quaternion.identity);            
               }
                else if (buildKind == BuildKind.BuildMine)//광산 짓기
                {
                    buildWarkerInstBool = true;
                    GameObject xpGameObject = Instantiate(xp, transform.position, Quaternion.identity);
                    GameObject warkerGameObject = Instantiate(buildPrefab[1], worldMousePosition, Quaternion.identity);
                }
                else if (buildKind == BuildKind.BuildTower)//타워(병사 훈련소) 짓기
                {
                    buildWarkerInstBool = true;
                    GameObject xpGameObject = Instantiate(xp, transform.position, Quaternion.identity);
                    GameObject warkerGameObject = Instantiate(buildPrefab[2], worldMousePosition, Quaternion.identity);
                }
            }
        }
    }
}
