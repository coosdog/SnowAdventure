using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventText : MonoBehaviour
{
    protected Dictionary<int, string[]> talkdata;
    public GameManager gameManager;
    public int ID;
    public int talkIndex = 0;
    public bool isSatan = false;

    public Sprite SelfImege;

    public void GenerateData()
    {
        talkdata.Add(1, new string[]
        { "����, ������ʹ� ���籸����. ���� �ȵ�.","...","�׷����� ��źŬ�ν����� ������ ���ָ� ã���� ���°ű���.",
        "�׷��ٸ� �̰��� �ʿ��Ұž�. ���� �������ΰ��̶� ��ο��״ϱ�.","�װ� ���� ��ȭ�� ������ŭ ��� �����ž�." , "���� �׸��� ��ź���� �������������� ������.",
        "����� ������ �������� ����"});
        talkdata.Add(2, new string[]
        {"������! ���ָ� ��ã���� ������� �Գ�!", "�㳪 ��� �������� ���̴�! ���ִ� �����ִ� �̰����� ���� ��ȥ���� �ø����̾�!",
            "ó���� ������!!!"});
        talkdata.Add(3, new string[]
        {"���ƿ�. �������� ������ �ձÿ��� ������ ������ ��ٸ���.", "�����༭ ������."
        });
        talkdata.Add(4, new string[]
        { "��ź Ŭ�ν��� ��ġ������!", " �� ���� ������ �ڷ���Ʈ ��ġ�� Ÿ�� �̰����� ����������!" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkdata[id].Length)
            return null;
        else
            return talkdata[id][talkIndex];
    }
    private void Start()
    {
        UpdateText();
    }
    public void TextAct()
    {
        gameManager.ChangeAction(gameObject);
    }

    public void UpdateText()
    {
        talkdata = new Dictionary<int, string[]>();
        GenerateData();
    }
}
