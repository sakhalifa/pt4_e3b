using PT4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PT4
{
    public static class Utils
    {
        
        public static int? connectedSalarieId;
        public static bool connecteAdmin;

        public static DialogResult ShowError(string text)
        {
            return MessageBox.Show(text, "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static List<T> GetRangeAndCut<T>(List<T> list, int offset, int count)
        {
            int realCount = count;
            if(count * (offset+1) > list.Count())
            {
                realCount = list.Count() / (offset + 1);
            }

            return list.GetRange(offset, realCount);
        }

        public static byte[] Hash(string clearPwd)
        {
            return SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(clearPwd));
        }

        public static void CreateCriteriaCheckFunc<T, V>(ref Expression<Func<V, bool>> expr, CriteriaCombinationType? combinationType, Func<Criteria<T>> provider, Expression<Func<V, T>> objectToExpr)
        {
            Criteria<T> criteria = provider();
            var pParameter = expr.Parameters[0];

            //We replace the parameter of the lambda with pParameter
            Expression prodToT = ReplacingExpressionVisitor.Replace(objectToExpr.Parameters[0], pParameter, objectToExpr.Body);

            //We have to re-lambda the converted expression :(
            var exprProd = Expression.Lambda(prodToT, pParameter);

            //We get the expression that checks the criteria
            var func = criteria.CreateFunctionFromCriteria();

            /*We replace the value we check with the property of p.
                (Conversion from Func<T, bool> to Func<PRODUIT, bool> basically).
                i.e: we convert for example (b) => b == true to (p) => p.property == true
                b is a boolean, p is a Product and p.property is a boolean
            */
            var newExpr = ReplacingExpressionVisitor.Replace(func.Parameters[0], exprProd.Body, func.Body);

            //Then we create the lambda that is basically the function (p) => func(p.property)
            var lambdaNew = Expression.Lambda<Func<V, bool>>(newExpr, pParameter);

            //If we don't have to combine it then we just return it.
            if (combinationType is null)
            {
                expr = lambdaNew;
            }
            else
            {
                if (combinationType == CriteriaCombinationType.AND)
                {
                    //We create an AND operation between the already established expression in {expr} and our criteria check function.
                    var andExpr = Expression.AndAlso(expr.Body, lambdaNew.Body);

                    //Then we create the lambda which is basically (p) => expr(p.property) && func(p.property)
                    expr = Expression.Lambda<Func<V, bool>>(andExpr, pParameter);
                }
                else
                {
                    //We create an OR operation between the already established expression in {expr} and our criteria check function.
                    var orExpr = Expression.OrElse(expr.Body, lambdaNew.Body);

                    //Then we create the lambda which is basically (p) => expr(p.property) || func(p.property)
                    expr = Expression.Lambda<Func<V, bool>>(orExpr, pParameter);
                }
            }
        }

        public static void RemoveLastCharacter(this StringBuilder sb)
        {
            sb.Remove(sb.Length - 1, 1);
        }
    }
}
