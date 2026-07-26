using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abood.Movies.Directors
{
    public class DirectorDto : AuditedEntityDto<Guid>
    {
        public String Name { get; set; }
        public String Nationality { get; set; }
    }
}