using UnityEngine;
//필드 : 변수
//메서드 : 함수
public class TestProperty : MonoBehaviour
{
    [SerializeField]
    private int hp = 100; 
    public int _hp
    {
        get { return hp; }
        set { hp = value; }
    }
 
    public int mp { get; set; } //자동 구현 프로퍼티

    public void ViewHPMP()
    {
        Debug.Log($"{hp} === {mp}");
    }
   
    protected void Die() // 메서드 상속받은 상태에서만 변경이 가능함
    {
        Debug.Log("죽음");
    }
}
