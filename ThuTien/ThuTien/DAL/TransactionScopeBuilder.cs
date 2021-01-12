using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ThuTien.DAL
{
    public static class TransactionScopeBuilder
    {
        public static TransactionScope CreateReadCommitted()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        }

        public static TransactionScope CreateReadUncommitted()
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted,
                Timeout = TransactionManager.DefaultTimeout
            };

            return new TransactionScope(TransactionScopeOption.Required, options);
        } 
    }
}
