namespace TicTacToe
{
    public class ContractResult
    {
        public bool OperationResult { get; private set; }
        public string Error { get; private set; }
        public TicTacToeGame Game { get; private set; }

        private ContractResult() { }

        public static ContractResult NewContractResult(bool operationResult, string error)
        {
            return new ContractResult
            {
                OperationResult = operationResult,
                Error = error
            };
        }

        public static ContractResult NewContractResult(bool operationResult, string error, TicTacToeGame game)
        {
            return new ContractResult
            {
                OperationResult = operationResult,
                Error = error,
                Game = game
            };
        }
    }
}
