using Microsoft.AspNetCore.Mvc;
using NetWebApi.Utils;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsynchronousExampleController : ControllerBase
    {
        [HttpGet("WithAwait")]
        public async Task<IActionResult> GetWithAwait()
        {
            AsynchronousExample example = new AsynchronousExample();

            await example.PerformStep1Async();
            await example.PerformStep2Async();
            await example.PerformStep3Async();
            await example.PerformStep4Async();

            return Ok(example.GetResult());
        }

        [HttpGet("WithoutAwait")]
        public async Task<IActionResult> GetWithoutAwait()
        {
            AsynchronousExample example = new AsynchronousExample();
            example.PerformStep1Async();
            example.PerformStep2Async();
            example.PerformStep3Async();
            example.PerformStep4Async();

            return Ok(example.GetResult());
        }

        [HttpGet("WithoutAwaitAll")]
        public async Task<IActionResult> GetWithoutAwaitAll()
        {
            AsynchronousExample example = new AsynchronousExample();

            Task.WaitAll(example.PerformStep1Async(),
                example.PerformStep2Async(),
                example.PerformStep3Async(),
                example.PerformStep4Async()
            );

            return Ok(example.GetResult());
        }

        [HttpGet("WithoutAwaitAny")]
        public async Task<IActionResult> GetWithoutAwaitAny()
        {
            AsynchronousExample example = new AsynchronousExample();

            Task.WaitAny(example.PerformStep1Async(),
                example.PerformStep2Async(),
                example.PerformStep3Async(),
                example.PerformStep4Async()
            );

            return Ok(example.GetResult());
        }

    }
}