using OriontaxSync.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OriontaxSync.libs.DAOSVR
{
    internal class ProdutoDAO : DefaultModel
    {
        public ProdutoDAO()
        {
            this.tabela = "produto";
        }

        public List<ProdutosBanco> GetProdctsToSend(bool temAlerta = false)
        {
            try
            {
                string query = @"
                    SELECT 
                    P.CODIGO [codigo] 
                    , IIF((P.Codigo_Fabricante1 LIKE '%.%' OR P.Codigo_Fabricante1 LIKE '%,%' OR LEN(P.Codigo_Fabricante1) < 8 OR P.Codigo_Fabricante1 LIKE '%-%'),'',P.Codigo_Fabricante1) [codigo1]
                    , IIF((P.Codigo_EAN LIKE '%.%' OR P.Codigo_EAN LIKE '%,%' OR LEN(P.Codigo_EAN) < 8 OR P.Codigo_EAN LIKE '%-%'),'',P.Codigo_EAN) [ean]
                    , P.NCM [ncm]
                    , P.NOME [descricao]
                    , ISNULL(C.CODIGO,'') [cest]
                    , CIO.Cfop__Codigo [cfop]
                    , CONVERT(INT, CIO.ICMSCST) [cst_csosn]
                    , CONVERT(DECIMAL(18,2),CIO.ICMSPERC) [icms_aliq]
                    , IIF(CIO.ICMSCST = 20, CONVERT(DECIMAL(18,2),CIO.ICMSPERC) - CONVERT(DECIMAL(18,2),CIO.IcmsPercDeson) , 0 ) [red_icms]
                    , CIO.PisCofinsTipo [pis_cofins_cst]
                    , CONVERT(DECIMAL(18,2),CIO.PISPERC) [pis_perc]
                    , CONVERT(DECIMAL(18,2),CIO.COFINSPERC) [cofins_perc]
                    , CI.CODIGO [cod_classe]
                    , CI.NOME [classe_imposto]
                    , CI.IDE [ide]
                    FROM PRODUTO P
                    LEFT JOIN CLASSEIMPOSTO CI ON CI.IDE = P.CLASSEIMPOSTO__IDE
                    LEFT JOIN CLASSEIMPOSTOOPERACAO CIO ON CIO.CLASSEIMPOSTO__IDE = CI.IDE
                    LEFT JOIN CLASSEIMPOSTOOPERACAOUF CIOU ON CIOU.CLASSEIMPOSTOOPERACAO__IDE = CIO.IDE
                    LEFT JOIN CEST C ON P.CEST = C.IDE LEFT JOIN MARCA M ON M.IDE = P.MARCA
                    WHERE  CIO.OPERACAO__CODIGO = 500
                     AND CIOU.UF = 'GO' 
                     AND ciou.status = 0
                     AND CIO.Cfop__Codigo like '5%'
                     AND LEN (CIO.icmscst) < 3
                     AND P.Inativo != 1  
                     AND P.Bloqueado != 1
                    ORDER BY CONVERT(int,P.CODIGO);";

                DataTable resp = this.ExecuteQuery(query);

                List<ProdutosBanco> produtos = resp.AsEnumerable()
                    .Select(row => new ProdutosBanco
                    {
                        Codigo = row.Field<string>("codigo"),
                        Codigo1 = row.Field<string>("codigo1"),
                        Ean = row.Field<string>("ean"),
                        Ncm = row.Field<string>("ncm"),
                        Descricao = row.Field<string>("descricao"),
                        Cest = row.Field<string>("cest"),
                        Cfop = row.Field<int>("cfop"),
                        CstCsosn = row.Field<int>("cst_csosn"),
                        IcmsAliq = row.Field<decimal>("icms_aliq"),
                        RedIcms = row.Field<decimal>("red_icms"),
                        PisCofinsCst = row.Field<string>("pis_cofins_cst"),
                        PisPerc = row.Field<decimal>("pis_perc"),
                        CofinsPerc = row.Field<decimal>("cofins_perc"),
                        CodClasse = row.Field<int>("cod_classe"),
                        ClasseImposto = row.Field<string>("classe_imposto"),
                        Ide = row.Field<Guid>("ide")
                    })
                    .ToList();

                return produtos;
            }
            catch (Exception ex)
            {
                if(temAlerta) Funcoes.ErrorMessage(ex.Message);
                return null;
            }
        }
    }
}
