using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriontaxSync.libs.DAOSVR
{
    internal class ProdutoDAO: DefaultModel
    {
        public ProdutoDAO() {
            this.tabela = "produto";
        }
    }
}
