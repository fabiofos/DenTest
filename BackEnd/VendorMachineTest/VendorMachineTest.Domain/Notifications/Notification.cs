using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorMachineTest.Domain.Notifications
{
    public class Notification : INotification
    {
        public string Message { get; private set; }

        public Notification(string message) =>
            Message = message;

        public Notification(ValidationResult result) =>
            Message = string.Join(Environment.NewLine, result.Errors?.Select(x => x.ErrorMessage));
    }
}
