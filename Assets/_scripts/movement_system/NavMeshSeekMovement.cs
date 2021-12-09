using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSeekMovement : IMovement
{
    #region PROPERTIES
    private NavMeshAgent m_agent;
    private Transform m_target;

    //private bool shouldFollow;
    //private Action onComplete;

    #endregion

    #region CONSTRUCTOR
    public NavMeshSeekMovement(NavMeshAgent agent, Transform target)
    {
        this.m_agent = agent;
        this.m_target = target;

        this.m_agent.SetDestination(this.m_target.position);

    }

    #endregion

    #region METHODS
    public void Move()
    {
        this.m_agent.SetDestination(m_target.position);
    }

    //public void SubscribeToEndCoroutine(Action handler)
    //{
    //    this.onComplete += handler;
    //}

    #endregion
}
