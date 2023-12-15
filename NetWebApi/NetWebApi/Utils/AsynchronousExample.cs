namespace NetWebApi.Utils
{
    public class AsynchronousExample
    {
        private readonly Random _random;
        private readonly int _randomMaxValue;
        private readonly List<string> _result;

        public AsynchronousExample()
        {
            this._random = new Random();
            this._randomMaxValue = 1000;
            this._result = new List<string>();
        }

        public async Task<List<string>> PerformStep1Async()
        {
            return await Task.Run(async () =>
               {
                   await Task.Delay(this._random.Next(this._randomMaxValue));
                   this._result.Add("Paso 1");
                   return this._result;
               });
        }

        public async Task<List<string>> PerformStep2Async()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(this._random.Next(this._randomMaxValue));
                this._result.Add("Paso 2");
                return this._result;
            });
        }

        public async Task<List<string>> PerformStep3Async()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(this._random.Next(this._randomMaxValue));
                this._result.Add("Paso 3");
                return this._result;
            });
        }

        public async Task<List<string>> PerformStep4Async()
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(this._random.Next(this._randomMaxValue));
                this._result.Add("Paso 4");
                return this._result;
            });
        }

        public List<string> GetResult()
        {
            return this._result;
        }
    }
}