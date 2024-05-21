// using System;
// using System.Windows.Input;
//
// namespace MyUtils.Commands
// {
//     public struct GenericCommand<T> : ICommand where T : struct
//     {
//         // /// <summary>
//         // ///     generic command
//         // /// </summary>
//         // /// <param name="data">old value</param>
//         // /// <param name="execute">input old value, return new value</param>
//         // /// <param name="undo">input old value and new value, return void</param>
//         // public GenericCommand(T data, Func<T, T> execute, Action<T, T> undo)
//         // {
//         //     #if UNITY_EDITOR
//         //     if (!typeof(T).IsSerializable)
//         //     {
//         //         throw new ArgumentException("T must be serializable");
//         //     }
//         //     #endif
//         //     _newValue = _oldValue = data;
//         //     _execute = execute;
//         //     _undo = undo;
//         // }
//
//         public bool Execute()
//         {
//             try
//             {
//                 _newValue = _execute(_oldValue);
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 DebugHelper.LogException(e);
//                 return false;
//             }
//         }
//
//         public bool Undo()
//         {
//             try
//             {
//                 _undo(_oldValue, _newValue);
//                 return true;
//             }
//             catch (Exception e)
//             {
//                 DebugHelper.LogException(e);
//                 return false;
//             }
//         }
//
//         #region Function
//
//         /// <summary>
//         ///     input old value, return new value
//         /// </summary>
//         public readonly Func<T, T> _execute;
//         /// <summary>
//         ///     input old value and new value, return void
//         /// </summary>
//         public readonly Action<T, T> _undo;
//
//         #endregion
//
//         #region Variable
//
//         private readonly T _oldValue;
//         private          T _newValue;
//
//         #endregion
//
//         public bool CanExecute(object parameter) => _execute!=null;
//
//         public void Execute(object parameter)
//         {
//             Execute();
//         }
//
//         public event EventHandler CanExecuteChanged;
//     }
// }

