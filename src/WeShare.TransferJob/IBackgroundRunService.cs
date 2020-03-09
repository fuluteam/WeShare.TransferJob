using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace WeShare.TransferJob
{
    public interface IBackgroundRunService
    {
        /// <summary>
        /// 执行后台作业
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Execute(CancellationToken cancellationToken);
        /// <summary>
        ///将作业转移到后台
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        void Transfer<T>(Expression<Func<T, Task>> expression);
        void Transfer(Expression<Action> expression);
    }
}