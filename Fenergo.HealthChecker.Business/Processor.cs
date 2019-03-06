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
        public Result Execute(List<int> types)
        {

            var result = new Result();
            foreach (var item in types) {
                var behaviour = DefineBehaviour(item).Execute();
            }

            if (result.Messages.Count > 0)
                result.Success = false;

            return result;
        }

        private IBehaviour DefineBehaviour(int type)
        {
            switch ((ProcessorTypeEnum)type)
            {
                case ProcessorTypeEnum.Bre:
                    return new Bre();
                case ProcessorTypeEnum.Fdim:
                    return new Fdim();
                case ProcessorTypeEnum.ElasticSearch:
                    return new ElasticSearch();
                case ProcessorTypeEnum.Queues:
                    return new Queues();
                default:
                    return new Default();
            }
        }
    }
}
