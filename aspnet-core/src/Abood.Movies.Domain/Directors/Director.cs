using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abood.Movies.Directors
{
    public class Director : AuditedAggregateRoot<Guid>
    {
        public String  Name { get; private set; }
        public String  Nationality {  get; private set; }
        protected Director()
        {
        }


        public Director(
            Guid id,
            string name,
            string nationality)
            : base(id)
        {
            SetName(name);
            SetNationality(nationality);
        }


        public Director SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                100);

            return this;
        }


        public Director SetNationality(string nationality)
        {
            Nationality = Check.NotNullOrWhiteSpace(
                nationality,
                nameof(nationality),
                100);

            return this;
        }
    }


}

