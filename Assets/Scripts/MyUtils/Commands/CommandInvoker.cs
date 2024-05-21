// using System.Collections.Generic;
// using System.Windows.Input;
//
// namespace MyUtils.Commands
// {
//     public static class CommandInvoker
//     {
//         private static Stack<ICommand> undoStack = new Stack<ICommand>();
//         private static Stack<ICommand> redoStack = new Stack<ICommand>();
//
//         public static void Clear()
//         {
//             undoStack.Clear();
//             redoStack.Clear();
//         }
//
//         public static void Execute(ICommand command)
//         {
//             command.Execute(command);
//             undoStack.Push(command);
//             redoStack.Clear();
//         }
//
//         public static bool Undo()
//         {
//             if (undoStack.Count == 0)
//             {
//                 return false;
//             }
//
//             ICommand command = undoStack.Pop();
//             bool result = command.Undo();
//             if (result)
//             {
//                 redoStack.Push(command);
//             }
//             else
//             {
//                 undoStack.Push(command);
//             }
//
//             return result;
//         }
//
//         public static bool Redo()
//         {
//             if (redoStack.Count == 0)
//             {
//                 return false;
//             }
//
//             ICommand command = redoStack.Pop();
//             bool result = command.Execute();
//             if (result)
//             {
//                 undoStack.Push(command);
//             }
//             else
//             {
//                 redoStack.Push(command);
//             }
//
//             return result;
//         }
//     }
// }

