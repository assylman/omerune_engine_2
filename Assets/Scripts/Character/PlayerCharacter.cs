using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override Character CharacterTarget
    {
        get
        {   
            Character target = null;
            float minDistance = float.MaxValue;
            List<Character> list = GameManager.Instance.CharactorFactory.ActiveCharacters;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CharacterType == CharacterType.Player)
                {
                    continue;
                }

                float distance = Vector3.Distance(list[i].transform.position, transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = list[i];
                }
            }
            return target;
        }
    }

    public override void Initialize()
    {
        Debug.Log("Initializing PlayerCharacter: " + name);
        base.Initialize();
        HealthComponent = new ImmortalHealthComponent();
        HealthComponent.Initialize(this);

        ControlsComponent = new DefaultControlsComponent();
        ControlsComponent.Initialize(this);
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0)
            return;

        ControlsComponent.OnUpdate();
    }
}
