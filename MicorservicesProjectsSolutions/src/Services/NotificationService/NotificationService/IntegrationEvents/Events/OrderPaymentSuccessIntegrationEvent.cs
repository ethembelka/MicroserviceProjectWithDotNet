﻿using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.IntegrationEvents.Events
{
    internal class OrderPaymentSuccessIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentSuccessIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
