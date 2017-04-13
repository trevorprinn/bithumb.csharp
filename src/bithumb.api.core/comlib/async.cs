using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace XCoin.API.ComLib
{
    /// <summary>
    /// 
    /// </summary>
    public static class ISynchronizeInvokeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            try
            {
                if (@this.InvokeRequired)
                {
                    @this.Invoke(action, new object[] { @this });
                }
                else
                {
                    action(@this);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void InvokeExForm(this Form @this, Action<Form> action)
        {
            try
            {
                if (@this.InvokeRequired)
                {
                    if (@this.IsDisposed == false)
                        @this.Invoke(action, new object[] { @this });
                }
                else
                {
                    action(@this);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }
    }
}