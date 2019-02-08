using System;

namespace Document
{
    internal class Program
    {
        public const string KeyPro = "111";
        public const string KeyExp = "555";

        public static string InputKey()
        {
            const string strRead = " If you have, please enter the key of the pro or " +
                                   "expert version,\n or leave the field blank to start " +
                                   "the trial version :";

            Console.WriteLine(strRead);

            return Console.ReadLine();
        }

        private static void CreatorController(string key)
        {
            switch (key)
            {
                case KeyPro:
                    GetResult((DocumentWorker) new ProDocumentWorker());
                    break;
                case KeyExp:
                    GetResult((DocumentWorker) new ExpertDocumentWorker());
                    break;
                default:
                    GetResult(new DocumentWorker());
                    break;
            }
        }

        private static void GetResult(DocumentWorker obj)
        {
            obj.OpenDocument();
            obj.EditDocument();
            obj.SaveDocument();
        }

        private static void GetResult(ProDocumentWorker obj)
        {
            obj.OpenDocument();
            obj.EditDocument();
            obj.SaveDocument();
        }

        private static void GetResult(ExpertDocumentWorker obj)
        {
            obj.OpenDocument();
            obj.EditDocument();
            obj.SaveDocument();
        }


        private static void WorkoutController()
        {
            const string strEsc =
                "(Now you can press Esc to exit or any key to continue....)";

            do
            {
                CreatorController(InputKey());
                Console.WriteLine(strEsc);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void Main()
        {
            WorkoutController();
        }

        private class DocumentWorker
        {
            public virtual void OpenDocument()
            {
                Console.WriteLine("Document open");
            }

            public virtual void EditDocument()
            {
                Console.WriteLine("PRO-version provides EDIT-functionality.");
            }

            public virtual void SaveDocument()
            {
                Console.WriteLine("PRO-version provides SAVE-functionality");
            }
        }

        private class ProDocumentWorker : DocumentWorker
        {
            public override void EditDocument()
            {
                Console.WriteLine("Document has been edited.");
            }

            public override void SaveDocument()
            {
                Console.WriteLine("Document has been saved using old format, " +
                                  "additional formats are available in EXPERT-version.");
            }
        }

        private class ExpertDocumentWorker : ProDocumentWorker
        {
            public override void SaveDocument()
            {
                Console.WriteLine("Document has been saved new format.");
            }
        }
    }
}