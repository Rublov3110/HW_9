using System;
using HW_9.Helpers;
using HW_9.Services.Abstractions;

namespace HW_9
{
    public class Actions
    {
        private readonly ILoggerService _loggerService;

        public Actions(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public bool MethodOne()
        {
            _loggerService.LogInfo($"Start method: {nameof(MethodOne)}");

            return true;
        }

        public bool MethodTwo()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public bool MethodThree()
        {
            throw new Exception("I broke a logic");
        }
    }
}