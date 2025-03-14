using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_FPT_SHOP.DesignPattern.UnitOfWorkPattern
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
