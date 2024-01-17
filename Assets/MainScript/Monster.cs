using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    void SetState(string name); // ���¹ٲٴ� �Լ�
    object GetOwner(); // ���׸��̱� ������ 
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
    protected Vector3 targetPos;
    public override void Init(IStateMachine sm)
    {
        base.Init(sm);
        monster = (Monster)sm.GetOwner();
    }
    public override void OnUpdate()
    {
        //���������Ǿ� ��Ʈ���� ��ġ
    }
}
public class MonsterPatrolState : MonsterState
{
    public override void OnEnter() 
    {
    }
    public override void OnExit() { }
    public override void OnUpdate() 
    {
        base.OnUpdate();
    }
}
public class MonsterReturnHState : MonsterState { }
public class MonsterTrackingState : MonsterState { }

public class StateMachine<T> : IStateMachine where T : class // Ȯ�� ���ɼ��� ����α� ���Ͽ� T�� ���
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
        if(stateDic.ContainsKey(name))
        {
            if(curState != null)
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


public class Monster : MonoBehaviour
{
    public GameObject targetPlace;

    private StateMachine<Monster> sm;
    public Animator animator;
    public Collider targetCollider; 
    void Start()
    {
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
}
