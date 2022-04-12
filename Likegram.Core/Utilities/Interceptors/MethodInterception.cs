using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAFter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }

        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                var task = invocation.ReturnValue as Task;
                if (task != null)
                {
                    if (!task.IsCompleted)
                    {
                        OnException(invocation, task.Exception);
                        isSuccess = false;
                    }
                }
            }
            catch (System.Exception e)
            {
                OnException(invocation, e);
                isSuccess = false;
                throw;
            }
            finally
            {
                if (isSuccess)
                    OnSuccess(invocation);
            }
            OnAFter(invocation);
        }
    }
}
