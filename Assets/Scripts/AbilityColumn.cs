using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AbilityColumn : MonoBehaviour
{

    // Random select one ability from this List.
    [SerializeField]
    private List<Ability> m_abilityPool;

    [SerializeField]
    private Text m_abilityName;

    [SerializeField]
    private List<Image> m_abilityIcons;

    [SerializeField]
    private float m_scrollDuration;

    private int m_curSelectedIconIndex = 1;

    [SerializeField]
    private Ability m_curAbility;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScrollDown()
    {
        StartCoroutine(ScrollDownPerform());
    }

    private IEnumerator ScrollDownPerform()
    {
        // 把目前的 Icon 往下捲
        var curIcon = m_abilityIcons[m_curSelectedIconIndex];
        curIcon.transform.DOLocalMoveY(-200f, m_scrollDuration).SetEase(Ease.Linear);


        // 幫藏在上面的 Icon 亂數挑選一個能力，然後拉進框框裡
        var nextIconIndex = (m_curSelectedIconIndex == 0) ? 1 : 0;
        var nextIcon = m_abilityIcons[nextIconIndex];

        var randomAbilityIndex = Random.Range(0, m_abilityPool.Count);

        // 避免重複出現的狀況發生
        if (m_abilityPool[randomAbilityIndex].Type == m_curAbility.Type)
        {
            randomAbilityIndex = (randomAbilityIndex + Random.Range(1, m_abilityPool.Count)) % m_abilityPool.Count;
        }

        m_curAbility = m_abilityPool[randomAbilityIndex];
        m_abilityName.text = m_curAbility.AbilityName;
        nextIcon.sprite = m_curAbility.AbilityIcon;

        nextIcon.transform.DOLocalMoveY(0f, m_scrollDuration).SetEase(Ease.Linear);

        yield return new WaitForSeconds(m_scrollDuration);

        // 捲動完畢後，再把原本被往下捲的 Icon 丟回上面
        curIcon.transform.localPosition = new Vector3(0f, 200f, 0f);


        // 刷新 curSelectedIconIndex
        m_curSelectedIconIndex = nextIconIndex;

        yield return null;
    }
}
