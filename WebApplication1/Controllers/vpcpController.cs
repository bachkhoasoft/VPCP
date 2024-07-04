using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class vpcpController: ControllerBase
    {

        private readonly VPCPService _vpcpService;
        public vpcpController(VPCPService vpcpService) =>
        _vpcpService = vpcpService;

        [HttpGet]
        public async Task<List<vpcp>> Get() =>
        await _vpcpService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<vpcp>> Get(string id)
        {
            var vpcp = await _vpcpService.GetAsync(id);

            if (vpcp is null)
            {
                return NotFound();
            
            }

            return vpcp;
        }

        [HttpPost]
        public async Task<IActionResult> Post(vpcp newvpcp)
        {
            await _vpcpService.CreateAsync(newvpcp);

            return CreatedAtAction(nameof(Get), new { id = newvpcp.Id }, newvpcp);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, vpcp updatevpcp)
        {
            var vpcp = await _vpcpService.GetAsync(id);

            if (vpcp is null)
            {
                return NotFound();
            }

            updatevpcp.Id = vpcp.Id;

            await _vpcpService.UpdateAsync(id, updatevpcp);

            return NoContent();
        }

        [HttpDelete("{id:length(100)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var vpcp = await _vpcpService.GetAsync(id);

            if (vpcp is null)
            {
                return NotFound();
            }

            await _vpcpService.RemoveAsync(id);

            return NoContent();
        }
    }
}
