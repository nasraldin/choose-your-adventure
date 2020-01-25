﻿using System.Threading.Tasks;

namespace ChooseYourAdventure.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}