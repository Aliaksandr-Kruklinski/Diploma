using System;
using System.Linq;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Domain.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }

        void SaveMessage(Message message);
    }
}
