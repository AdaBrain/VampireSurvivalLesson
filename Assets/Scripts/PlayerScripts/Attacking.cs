using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject skillPrefab;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(AutoAttack());
    }

    private IEnumerator AutoAttack()
    {        
        while(true)
        {
            anim.SetTrigger("IsSpecial");
            UseSkill();
            yield return new WaitForSeconds(cooldown);
        }
    }

    private void UseSkill()
    {
        GameObject skillClone = Instantiate(skillPrefab, transform.position, Quaternion.identity);

        Destroy(skillClone, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
