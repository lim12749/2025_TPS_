using JetBrains.Annotations;
using UnityEngine;

public abstract class PlayerStates : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxhp; //최대 체력
    [SerializeField] private int hp; //현재 체력
    public int Hp { 
        get { return hp;} 
        set { hp = value;}
    }
    [SerializeField] private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField] private int currentexp;
    public int CurrentExp
    {
        get { return currentexp; }
        set { currentexp = value; }
    }

    [SerializeField] private int expToNextLevel; //다음까지 필요한 경험치량
    // public int expToNextLevel {{get return expToNextLevel}}
    public int ExpToNextLevel => expToNextLevel; //압축한 람다식

    public virtual void Start()
    {
        Stateinitialization();
    }

    public void Stateinitialization()
    {
        Hp = maxhp; //초기 체력 설정
        Level = 1; //초기 레벨 설정
    }
    public virtual void LevelUp()
    {
        Debug.Log("부모 클래스");
        Level = 2; //레벨 증가

    }//레벨업 메소드, 추상 메소드로 선언
    public void TakeDamage(int _damage)
    {
       
    }
}
