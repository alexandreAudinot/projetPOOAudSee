using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetPOO
{
    public abstract class AbstractFactory : IFactory
    {

        void IFactory.createUnit()
        {
            throw new NotImplementedException();
        }
    }
}
