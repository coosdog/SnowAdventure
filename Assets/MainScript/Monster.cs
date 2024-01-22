using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using static Interface;

public interface IStateMachine
{
    void SetState(string name); // 상태바꾸는 함수
    object GetOwner(); // 제네릭이기 때문에 
}
public class State
{
    public IStateMachine sm;

    public virtual void Init(IStateMachine sm)
    {
        this.sm = sm;
    }
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }
}
public class MonsterState : State
{
    protected Monster monster;
    protected Vector3 thisPos;
    protected Vector3 targetPos;
    protected Vector3 dir;
    protected Collider[] cols;
    protected int moveSpeed = 3;
    float serchRange = 4f;

    

    public override void Init(IStateMachine sm)
    {
        base.Init(sm);
        monster = (Monster)sm.GetOwner();
        thisPos = monster.transform.position;
    }
    public override void OnUpdate()
    {
        cols = Physics.OverlapSphere(monster.transform.position, serchRange, 1 << 7);
        if (cols.Length > 0)
        {
            targetPos = cols[0].transform.position;
            monster.transform.LookAt(targetPos);
            sm.SetState("Tracking");
        }
        //오버랩스피어 터트려서 서치
    }
}
public class MonsterPatrolState : MonsterState
{

    public override void OnEnter()
    {
        targetPos = monster.targetPlace.transform.position;
    }
    public override void OnExit() { }
    public override void OnUpdate()
    {
        base.OnUpdate();
        dir = targetPos - monster.transform.position;
        dir = dir.normalized;
        monster.transform.LookAt(targetPos);
        monster.transform.position += dir * Time.deltaTime * moveSpeed;
        if (Vector3.Distance(targetPos, monster.transform.position) <= 0.5f)
        {
            sm.SetState("ReturnH");
        }
    }
}
public class MonsterReturnHState : MonsterState
{
    public override void OnEnter()
    {

    }
    public override void OnExit() 
    {
        targetPos = monster.targetPlace.transform.position;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        dir = thisPos - monster.transform.position;
        dir = dir.normalized;
        monster.transform.LookAt(thisPos);
        monster.transform.position += dir * Time.deltaTime * moveSpeed;
        if (Vector3.Distance(thisPos, monster.transform.position) <= 0.5f)
            sm.SetState("Patrol");
    }
}
public class MonsterTrackingState : MonsterState
{
    public override void OnEnter()
    {
    }
    public new void OnExit() 
    {
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        dir = targetPos - monster.transform.position;
        dir = dir.normalized;
        monster.transform.position += dir*Time.deltaTime * moveSpeed;
        if (cols.Length < 1)
        {
            sm.SetState("ReturnH");
        }
    }
}

public class StateMachine<T> : IStateMachine where T : class // 확장 가능성을 열어두기 위하여 T를 사용
{
    public T owner = null;
    public State curState = null;

    Dictionary<string, State> stateDic = null;

    public StateMachine()
    {
        stateDic = new Dictionary<string, State>();
    }

    public void AddState(string name, State state)
    {
        if (stateDic.ContainsKey(name))
            return;
        state.Init(this);
        stateDic.Add(name, state);
    }
    public object GetOwner()
    {
        return owner;
    }

    public void SetState(string name)
    {
        if (stateDic.ContainsKey(name))
        {
            if (curState != null)
                curState.OnExit();
            curState = stateDic[name];
            curState.OnEnter();
        }
    }
    public void Update()
    {
        curState.OnUpdate();
    }
}


public class Monster : MonoBehaviour, IHitable
{
    public GameObject targetPlace;

    private StateMachine<Monster> sm;
    public Animator animator;
    public Collider targetCollider;
    void Start()
    {
        animator = GetComponent<Animator>();

        sm = new StateMachine<Monster>();
        sm.owner = this;
        sm.AddState("Patrol", new MonsterPatrolState());
        sm.AddState("ReturnH", new MonsterReturnHState());
        sm.AddState("Tracking", new MonsterTrackingState());

        sm.SetState("Patrol");
    }

    void Update()
    {
        sm.Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }

    public void Hit()
    {
        gameObject.SetActive(false);
    }
}
