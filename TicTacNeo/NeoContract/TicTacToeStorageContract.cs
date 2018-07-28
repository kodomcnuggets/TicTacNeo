using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoContract
{
    public class TicTacToeStorageContract : SmartContract
    {
        public static string Main(string operation, params object[] args)
        {
            string error = "null";
            if (Runtime.Trigger == TriggerType.Application)
            {
                if (operation == "save")
                {
                    if (args.Count() == 2)
                        return Save((string)args[0], (string)args[1]);

                    error = "Incorrect number of args (" + args.Count() + ") for operation (" + operation + ")";
                }

                if (operation == "read")
                {
                    if (args.Count() == 1)
                        return Read((string)args[0]);

                    error = "Incorrect number of args (" + args.Count() + ") for operation (" + operation + ")";
                }

                error = "Invalid operation (" + operation + ")";
            }

            return "{ \"ContractResult\": false, \"Errors\": " + error  + " }";
        }

        private static string Save(string gameId, string game)
        {
            Storage.Put(Storage.CurrentContext, gameId, game);
            return "{ \"ContractResult\": true, \"Error\": null }";
        }

        private static string Read(string gameId)
        {
            var game = Convert.ToString(Storage.Get(Storage.CurrentContext, gameId));
            string contractResult;
            string error;
            if (string.IsNullOrEmpty(game))
            {
                contractResult = "false";
                error = "Game not found (" + gameId + ")";
            }
            else
            {
                contractResult = "true";
                error = "null";
            }
            return "{ \"ContractResult\": " + contractResult + ", \"Errors\": " + error + " }";
        }
    }
}
