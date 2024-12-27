using TMPro;
using UnityEngine;
public class Training : MonoBehaviour
{
    public GameManager gameManager;
    Warrior warrior;
    Archer archer;
    //Training

    public enum TrainingType { Null, Arrow_len, Arrow_DamageUP, Warrior_DamageUp, Warrior_HpUp };
    public TrainingType[] trainingTypeUI = new TrainingType[4]; // �ʱ�ȭ �߰�
    //��ư�� ������ ��ư �ִϸ��̼� Ȱ��ȭ
    public Animator[] level_Gauge_GameObject;
    //���� ����{"0:arrow_Len", "1:arrow_Power","2:warrior_Damage", "3:Warrior_HpUp"}
    public int[] level = new int[4];

    //�ִϸ��̼� Ȱ��ȭ
    public GameObject[] arrowLenLevelGameObjects;
    public GameObject[] arrowPowerLevelGameObject;
    public GameObject[] warriorHpLevelGameObjects;
    public GameObject[] warriorPowerLevelGameObject;

    //�Ʒ�Ƚ�� ����{"0:arrow_Len", "1:arrow_Power","2:warrior_Damage", "3:Warrior_HpUp"}
    public int[] trainingCounts = new int[4];
    //�Ʒ�Ƚ�� ����{"0:arrow_Len", "1:arrow_Power","2:warrior_Damage", "3:Warrior_HpUp"}
    public int[][] trainingMaxCounts = new int[4][];

    public TextMeshProUGUI[] trainingLevelText;
    public TextMeshProUGUI[] trainingCountText;
    public TextMeshProUGUI[] trainingCostsText;

    public int[][] enhance = new int[4][];

    bool[] buttonBool = { true, true, true, true };

    private void Start()
    {
        enhance[0] = new int[] { 3, 4, 5, 6, 7 };//�ü� ��Ÿ�
        enhance[1] = new int[] { 10, 12, 14, 16, 20 };//�ü� �����
        enhance[2] = new int[] { 4, 5, 6, 7, 10 };//���� �����
        enhance[3] = new int[] { 200, 230, 260, 290, 320 };//���� ü��

        trainingMaxCounts[0] = new int[] { 30, 40, 50, 60, 70 };
        trainingMaxCounts[1] = new int[] { 40, 50, 60, 70, 80 };
        trainingMaxCounts[2] = new int[] { 35, 55, 65, 80, 100 };
        trainingMaxCounts[3] = new int[] { 30, 40, 50, 60, 70 };
    }
    private void Update()
    {
        warrior = FindObjectOfType<Warrior>();
        archer = FindObjectOfType<Archer>();
        if (warrior != null)
        {
            warrior.warriorHp = enhance[3][level[3]];
        }
        else if (archer != null)
        {
            archer.attackRange = enhance[0][level[0]];
        }

        //������ �ö������ = �Ʒ����� �� �ִϸ��̼� ����
        FalseAnimation();
    }

    void FalseAnimation()
    {
        UpdateTrainingUI();
    }

    void UpdateTrainingUI()
    {
        // �� �Ʒ� Ÿ�Կ� ���� �Ʒ� ���� ������Ʈ

        if (trainingCounts[0] == 0)
        {         
            buttonBool[0] = true;
            if (level[0] == 1)
            {
                trainingLevelText[0].text = "LV:" + level[0].ToString();
                trainingCountText[0].text = "��Ÿ�\n ����";
                trainingCostsText[0].text = "�� " + trainingMaxCounts[0][1] + "�� �ʿ��մϴ�.";

                arrowLenLevelGameObjects[level[0] - 1].SetActive(false);
            }
            else if (level[0] == 2)
            {
                trainingLevelText[0].text = "LV:" + level[0].ToString();
                trainingCountText[0].text = "��Ÿ�\n ����";
                trainingCostsText[0].text = "�� " + trainingMaxCounts[0][2] + "�� �ʿ��մϴ�.";

                arrowLenLevelGameObjects[level[0] - 1].SetActive(false);
            }
            else if (level[0] == 3)
            {
                trainingLevelText[0].text = "LV:" + level[0].ToString();
                trainingCountText[0].text = "��Ÿ�\n ����";
                trainingCostsText[0].text = "�� " + trainingMaxCounts[0][3] + "�� �ʿ��մϴ�.";

                arrowLenLevelGameObjects[level[0] - 1].SetActive(false);
            }
            else if (level[0] == 4)
            {
                trainingLevelText[0].text = "LV:" + level[0].ToString();
                trainingCountText[0].text = "��Ÿ�\n ����";
                trainingCostsText[0].text = "�� " + trainingMaxCounts[0][4] + "�� �ʿ��մϴ�.";

                arrowLenLevelGameObjects[level[0] - 1].SetActive(false);
            }
        }



        if (trainingCounts[1] == 0)
        {
            buttonBool[1] = true;
            if (level[1] == 1)
            {
                trainingLevelText[1].text = "LV:" + level[1].ToString();
                trainingCountText[1].text = "���ݷ�\n ����";
                trainingCostsText[1].text = "�� " + trainingMaxCounts[1][1] + "�� �ʿ��մϴ�.";

                arrowPowerLevelGameObject[level[1] - 1].SetActive(false);
            }
            else if (level[1] == 2)
            {
                trainingLevelText[1].text = "LV:" + level[1].ToString();
                trainingCountText[1].text = "���ݷ�\n ����";
                trainingCostsText[1].text = "�� " + trainingMaxCounts[1][2] + "�� �ʿ��մϴ�.";

                arrowPowerLevelGameObject[level[1] - 1].SetActive(false);
            }
            else if (level[1] == 3)
            {
                trainingLevelText[1].text = "LV:" + level[1].ToString();
                trainingCountText[1].text = "���ݷ�\n ����";
                trainingCostsText[1].text = "�� " + trainingMaxCounts[1][3] + "�� �ʿ��մϴ�.";

                arrowPowerLevelGameObject[level[1] - 1].SetActive(false);
            }
            else if (level[1] == 4)
            {
                trainingLevelText[1].text = "LV:" + level[1].ToString();
                trainingCountText[1].text = "���ݷ�\n ����";
                trainingCostsText[1].text = "�� " + trainingMaxCounts[1][4] + "�� �ʿ��մϴ�.";

                arrowPowerLevelGameObject[level[1] - 1].SetActive(false);
            }
        }


        if (trainingCounts[2] == 0)
        {
            buttonBool[2] = true;
            if (level[2] == 1)
            {
                trainingLevelText[2].text = "LV:" + level[2].ToString();
                trainingCountText[2].text = "ü��\n ����";
                trainingCostsText[2].text = "�� " + trainingMaxCounts[2][1] + "�� �ʿ��մϴ�.";
                warriorPowerLevelGameObject[level[2] - 1].SetActive(false);
            }
            else if (level[2] == 2)
            {
                trainingLevelText[2].text = "LV:" + level[2].ToString();
                trainingCountText[2].text = "ü��\n ����";
                trainingCostsText[2].text = "�� " + trainingMaxCounts[2][2] + "�� �ʿ��մϴ�.";

                warriorPowerLevelGameObject[level[2] - 1].SetActive(false);
            }
            else if (level[2] == 3)
            {
                trainingLevelText[2].text = "LV:" + level[2].ToString();
                trainingCountText[2].text = "ü��\n ����";
                trainingCostsText[2].text = "�� " + trainingMaxCounts[2][3] + "�� �ʿ��մϴ�.";

                warriorPowerLevelGameObject[level[2] - 1].SetActive(false);
            }
            else if (level[2] == 4)
            {
                trainingLevelText[2].text = "LV:" + level[2].ToString();
                trainingCountText[2].text = "ü��\n ����";
                trainingCostsText[2].text = "�� " + trainingMaxCounts[2][4] + "�� �ʿ��մϴ�.";

                warriorPowerLevelGameObject[level[2] - 1].SetActive(false);
            }
        }


        if (trainingCounts[3] == 0)
        {
            buttonBool[3] = true;
            if (level[3] == 1)
            {
                trainingLevelText[3].text = "LV:" + level[3].ToString();
                trainingCountText[3].text = "���ݷ�\n ����";
                trainingCostsText[3].text = "�� " + trainingMaxCounts[3][1] + "�� �ʿ��մϴ�.";

                warriorHpLevelGameObjects[level[3] - 1].SetActive(false);
            }
            else if (level[3] == 2)
            {
                trainingLevelText[3].text = "LV:" + level[3].ToString();
                trainingCountText[3].text = "���ݷ�\n ����";
                trainingCostsText[3].text = "�� " + trainingMaxCounts[3][2] + "�� �ʿ��մϴ�.";

                warriorHpLevelGameObjects[level[3] - 1].SetActive(false);
            }
            else if (level[3] == 3)
            {
                trainingLevelText[3].text = "LV:" + level[3].ToString();
                trainingCountText[3].text = "���ݷ�\n ����";
                trainingCostsText[3].text = "�� " + trainingMaxCounts[3][3] + "�� �ʿ��մϴ�.";

                warriorHpLevelGameObjects[level[3] - 1].SetActive(false);
            }
            else if (level[3] == 4)
            {
                trainingLevelText[3].text = "LV:" + level[3].ToString();
                trainingCountText[3].text = "���ݷ�\n ����";
                trainingCostsText[3].text = "�� " + trainingMaxCounts[3][4] + "�� �ʿ��մϴ�.";

                warriorHpLevelGameObjects[level[3] - 1].SetActive(false);
            }
        }


    }

    void Level(int levelIndex)
    {

        for (int i = 0; i < 4; i++)
        {
            switch (level[levelIndex])
            {
                case 1:
                    trainingCounts[levelIndex] = trainingMaxCounts[levelIndex][0];
                    break;
                case 2:
                    trainingCounts[levelIndex] = trainingMaxCounts[levelIndex][1];
                    break;
                case 3:
                    trainingCounts[levelIndex] = trainingMaxCounts[levelIndex][2];
                    break;
                case 4:
                    trainingCounts[levelIndex] = trainingMaxCounts[levelIndex][3];
                    break;
            }
        }
    }

    public void lenTraining()
    {
        if (gameManager.moneyCount > trainingMaxCounts[0][level[0]] + 1 && buttonBool[0])
        {
            buttonBool[0] = false;
            trainingTypeUI[0] = TrainingType.Arrow_len;
            trainingCountText[0].text = trainingCounts[0].ToString();
            gameManager.moneyCount -= trainingMaxCounts[0][level[0]];
            UpdateTraing(0);
            Level(0);
        }
    }

    // ȭ�� ���ݷ� Ʈ���̴� ����
    public void PowerTraining()
    {
        if (gameManager.moneyCount > trainingMaxCounts[1][level[1]] + 1 && buttonBool[0])
        {
            buttonBool[1] = false;
            trainingTypeUI[1] = TrainingType.Arrow_DamageUP;
            trainingCountText[1].text = trainingCounts[1].ToString();
            gameManager.moneyCount -= trainingMaxCounts[1][level[1]];
            UpdateTraing(1);
            Level(1);
        }
    }

    // ���� ���ݷ� Ʈ���̴� ����
    public void WarriorPowerTraining()
    {
        if (gameManager.moneyCount > trainingMaxCounts[2][level[2]] + 1 && buttonBool[0])
        {
            buttonBool[2] = false;
            trainingTypeUI[2] = TrainingType.Warrior_DamageUp;
            trainingCountText[2].text = trainingCounts[2].ToString();
            gameManager.moneyCount -= trainingMaxCounts[2][level[2]];
            UpdateTraing(2);
            Level(2);
        }
    }

    // ���� ���¹̳� Ʈ���̴� ����
    public void staminaTraining()
    {
        if (gameManager.moneyCount > trainingMaxCounts[3][level[3]] + 1 && buttonBool[0])
        {
            buttonBool[3] = false;
            trainingTypeUI[3] = TrainingType.Warrior_HpUp;
            trainingCountText[3].text = trainingCounts[3].ToString();
            gameManager.moneyCount -= trainingMaxCounts[3][level[3]];
            UpdateTraing(3);
            Level(3);
        }
    }

    //0:arrow_Len", "1:arrow_Power","2:warrior_Hp", "3:warrior_Damage"
    void UpdateTraing(int trainingTypeBools)
    {
        //�ü� ��Ÿ� �Ʒ�
        if (trainingTypeUI[trainingTypeBools] == TrainingType.Arrow_len)
        {
            for (int lenCount = 0; lenCount < 5; lenCount++)
            {
                if (lenCount == level[0])
                {
                    arrowLenLevelGameObjects[lenCount].SetActive(true);
                    level_Gauge_GameObject[0].enabled = true;
                }
                else
                {
                    arrowLenLevelGameObjects[lenCount].SetActive(false);
                }
            }
        }

        if (trainingTypeUI[trainingTypeBools] == TrainingType.Arrow_DamageUP)
        {
            for (int damageCount = 0; damageCount < 5; damageCount++)
            {
                if (damageCount == level[1])
                {
                    arrowPowerLevelGameObject[damageCount].SetActive(true);
                    level_Gauge_GameObject[1].enabled = true;
                }
                else
                {
                    arrowPowerLevelGameObject[damageCount].SetActive(false);
                }
            }
        }

        if (trainingTypeUI[trainingTypeBools] == TrainingType.Warrior_DamageUp)
        {
            for (int damageUpCount = 0; damageUpCount < 5; damageUpCount++)
            {
                if (damageUpCount == level[2])
                {
                    warriorPowerLevelGameObject[damageUpCount].SetActive(true);
                    level_Gauge_GameObject[2].enabled = true;
                }
                else
                {
                    warriorPowerLevelGameObject[damageUpCount].SetActive(false);
                }
            }
        }

        if (trainingTypeUI[trainingTypeBools] == TrainingType.Warrior_HpUp)
        {
            for (int hpUPCount = 0; hpUPCount < 5; hpUPCount++)
            {
                if (hpUPCount == level[3])
                {
                    warriorHpLevelGameObjects[hpUPCount].SetActive(true);
                    level_Gauge_GameObject[3].enabled = true;
                }
                else
                {
                    warriorHpLevelGameObjects[hpUPCount].SetActive(false);
                }
            }
        }
    }
}
