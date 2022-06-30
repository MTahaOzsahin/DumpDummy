using SurviveBoy.Abstract;
using SurviveBoy.Concretes.Animations;
using SurviveBoy.Concretes.Movement;
using SurviveBoy.Concretes.StateMachine;
using SurviveBoy.Concretes.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Controllers
{
    public class EnemiesController : MonoBehaviour, IEntityController
    {
        StatesMachine _statesMachine;
        Transform _playerController;

        [Header("Movements")]
        [SerializeField] Transform[] patrols;
        [Header("Chase")]
        [SerializeField] float chaseDistance = 10f;
        [Header("Run")]
        [SerializeField] bool isRunning;
        [Header("Level3")]
        [SerializeField] bool isLevel3;

        private void Awake()
        {
            _statesMachine = new StatesMachine();
            _playerController = FindObjectOfType<PlayerController>().transform;
        }
        IEnumerator Start()
        {
            IMover mover = new Mover(this);
            IAnimations animations = new PlayerAnimation(GetComponent<Animator>());

            Idle idle = new Idle(animations);
            Walk walk = new Walk(this,mover, animations, patrols);
            Chase chase = new Chase(this, _playerController, animations, mover);
            Run run = new Run(this, mover, animations, patrols);
            Runner Runner = new Runner(this, mover, animations, _playerController);
            Empty empty = new Empty();

            _statesMachine.AddTransition(idle, walk, () => !idle.IsIdle);
            _statesMachine.AddTransition(idle, chase,() => IsPlayerNear());
            _statesMachine.AddTransition(walk, chase, () => IsPlayerNear());
            _statesMachine.AddTransition(walk, idle, () => !walk.IsWalking);
            _statesMachine.AddTransition(chase, idle, () => !IsPlayerNear());
            _statesMachine.AddTransition(run, empty, () => !run.isRunning);
            _statesMachine.AddTransition(empty, run, () => true);
            _statesMachine.AddTransition(Runner, empty, () => !Runner.isLevel3);
            _statesMachine.AddTransition(empty, Runner, () => true);

            _statesMachine.AddAnyState(run, () => isRunning);
            _statesMachine.AddAnyState(Runner, () => isLevel3);

            _statesMachine.SetState(idle);

            yield return new WaitForSeconds(2f);
            isRunning = false;
            isLevel3 = false;


            yield return null;
        }
        private void Update()
        {
            _statesMachine.Action();
        }
        bool IsPlayerNear()
        {
            float distance = Mathf.Abs(Vector3.Distance(transform.position, _playerController.position));
            if (distance > chaseDistance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
