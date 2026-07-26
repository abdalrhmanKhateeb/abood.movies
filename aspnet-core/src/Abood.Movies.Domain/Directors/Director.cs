using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Directors
{
    public class Director : AuditedAggregateRoot<Guid>
    {
        public String  Name { get; set; }
        public String  Nationality {  get; set; }
        

    }
}
