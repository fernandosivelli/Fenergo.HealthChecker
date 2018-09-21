using Fenergo.HealthChecker.Behaviours;
using Fenergo.HealthChecker.Business.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fenergo.HealthChecker.Business
{
    public class Processor
    {
        public Result Execute(List<ProcessorTypeEnum> types)
        {
            var result =  DefineBehaviour(types.First()).Execute();
            if (result.Messages.Count > 0)
                result.Success = false;

            return result;
        }

        private IBehaviour DefineBehaviour(ProcessorTypeEnum type)
        {
            switch (type)
            {
                case ProcessorTypeEnum.Environment:
                    return new Behaviours.Environment();
                case ProcessorTypeEnum.ApplicationUi:
                    return new ApplicationUi();
                case ProcessorTypeEnum.Msmq:
                    return new Msmq();
                case ProcessorTypeEnum.Fdim:
                    return new Fdim();
                case ProcessorTypeEnum.Bre:
                    return new Bre();
                default:
                    return new Default();
            }
        }
    }
}
