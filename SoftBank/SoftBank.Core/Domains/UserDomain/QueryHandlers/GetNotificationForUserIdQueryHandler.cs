using SoftBankApp.Core;
using SoftBankApp.Core.Domains.UserDomain.Queries;
using SoftBankApp.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SoftBankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetNotificationForUserIdQueryHandler : IHandleQuery<GetNotificationForUserIdQuery, IEnumerable<NotificationModel>>
    {
        private readonly GenericRepository<Notifications> _notificationRepository;

        public GetNotificationForUserIdQueryHandler(GenericRepository<Notifications> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public IEnumerable<NotificationModel> Handle(GetNotificationForUserIdQuery query)
        {
            var notifications = _notificationRepository.GetAll().Where(x=>x.Login.Id == query.UserId && x.IsDisplayed == false);

            //TODO: Set IsDisplayed to false
            //_notificationRepository.Update()

            return notifications.Select(x => new NotificationModel
            {
                Message = x.Message
            });
        }
    }
}
