using UnityEngine;
using System.Collections;

public class HumanState : State {

	protected HumanBehaviour human;

	public HumanState(StateMachine sm,  HumanBehaviour h) : base(sm)
	{
		human = h;
	}
}
