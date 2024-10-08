﻿using BJJ9B1_HFT_2022231.Models;
using BJJ9B1_HFT_2022231.Repository.DbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BJJ9B1_HFT_2022231.Repository.ModelRepository
{
    public class DriverRepository : Repository<Drivers>, IRepository<Drivers>
    {
        public DriverRepository(F1DbContext ctx) : base(ctx)
        {
        }

        public override Drivers Read(int id)
        {
            return ctx.Drivers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Drivers item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
