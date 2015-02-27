using SocialNetwork.Domain.Abstract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Domain.Concrete
{
    public class EFMessageRepository: IMessageRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Message> Messages
        {
            get
            {
                return context.Messages;
            }
        }

        public void SaveMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }
    }
}
