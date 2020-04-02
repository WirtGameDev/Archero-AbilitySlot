using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    //基本能力 -> 左邊Column
    攻擊提升,
    攻速提升,
    回復生命,
    生命提高,

    //屬性攻擊 -> 中間Column
    火焰,
    冰凍,
    雷電,
    淬毒,

    //特殊攻擊 -> 右邊Column
    怪物彈射,
    正向箭,
    連續射擊,
    爆頭,
}

public class PowerUpController : MonoBehaviour
{

    [SerializeField]
    private List<AbilityColumn> m_abilityColumns;

    [SerializeField]
    private List<int> m_columnScrollCycle;

    private bool m_isScrolling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGenerateAbility()
    {
        if (m_isScrolling)
            return;

        StartCoroutine(GenerateAbilityPerform());
    }

    private IEnumerator GenerateAbilityPerform()
    {
        m_isScrolling = true;
        var curCycle = 0;

        while (true)
        {
            if (curCycle < m_columnScrollCycle[0])
            {
                ScrollAbilityColumn(0);
            }

            if (curCycle < m_columnScrollCycle[1])
            {
                ScrollAbilityColumn(1);
            }

            if (curCycle < m_columnScrollCycle[2])
            {
                ScrollAbilityColumn(2);
            }

            if (curCycle >= m_columnScrollCycle[2])
            {
                m_isScrolling = false;
                yield break;
            }

            yield return new WaitForSeconds(0.12f);

            curCycle++;
        }
    }

    private void ScrollAbilityColumn(int index)
    {
        m_abilityColumns[index].ScrollDown();
    }
}
