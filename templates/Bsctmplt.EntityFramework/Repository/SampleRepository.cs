using Bscframework.EFCore;
using Bsctmplt.Entity;
using Bsctmplt.EntityFrameworkCore;
using Bsctmplt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsctmplt.EntityFramework.Repository
{
    public class SampleRepository(BsctmpltDbContext context) : GenericRepository<Sample, int, BsctmpltDbContext>(context), ISampleRepository
    {
    }
}
