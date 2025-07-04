﻿﻿using EmissionDataRecordService.Data;
using EmissionDataRecordService.Model;
using EmissionDataRecordService.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmissionDataRecordService.Controllers
{
    [ApiExplorerSettings(GroupName = "Data")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmissionDataController : ControllerBase
    {
        private readonly IEmissionDataService _service;
        private readonly ILogger<EmissionDataController> _logger;

        public EmissionDataController(IEmissionDataService service, ILogger<EmissionDataController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<EmissionDataController>
        [HttpGet("/api/emissions")]
        public ActionResult<List<EmissionDataRecord>> GetAllEmissions()
        {
            _logger.LogInformation("Fetching all emission data records.");
            var allEmissions = _service.GetAllEmissionDataRecords();
            return Ok(allEmissions);
        }

        // GET api/<EmissionDataController>/5
        [HttpGet("/api/emissions/material")]
        public ActionResult<List<EmissionDataRecord>> GetMaterialNo([FromQuery]string? materialNo)
        {
            _logger.LogInformation($"Fetching emission data records for material number: {materialNo}");
            if (string.IsNullOrEmpty(materialNo))
            {
                _logger.LogWarning("Material number cannot be null or empty.");
                throw new ArgumentException("Material number cannot be null or empty.", nameof(materialNo));
            }
           
            var allCodes = _service.GetByMaterialNo(materialNo);
            return Ok(allCodes);           
        }

        // GET api/<EmissionDataController>/5
        [HttpGet("/api/emissions/country")]
        public ActionResult<List<EmissionDataRecord>> GetCountryCode([FromQuery] string? isoCode)
        {
            if (isoCode.Length != 2)
            {
                _logger.LogWarning("ISO country code cannot be null.");
                throw new ArgumentException("ISO country code cannot be null or empty.", nameof(isoCode));
            }
            _logger.LogInformation($"Fetching emission data records for country code: {isoCode}");            
            var allCodes = _service.GetByCountryCode(isoCode);
            return Ok(allCodes);
        }

        // POST api/<EmissionDataController>
        [HttpPost("/api/emissions")]
        public ActionResult<EmissionDataRecord> AddEmission([FromBody] EmissionDataRecord emissionDataRecord)
        {
            _logger.LogInformation("Adding new emission data record.");

            if (emissionDataRecord == null)
            {
                _logger.LogError("Emission data record cannot be null.");
                return BadRequest("Emission data record cannot be null or empty.");
            }       
           
            var addedRecord = _service.AddNewEmission(emissionDataRecord);

            return Ok(addedRecord);
        }

        // PUT api/<EmissionDataController>/5
        [HttpPut("/api/emissions/material")]
        public ActionResult<EmissionDataRecord> UpdateEmission(string materialNo, [FromBody] EmissionDataRecord emissionDataRecord)
        {
            _logger.LogInformation($"Updating emission data record for material number: {materialNo}");

            if (string.IsNullOrEmpty(materialNo) || emissionDataRecord == null)
            {
                _logger.LogError("Material number or emission data cannot be null or empty.");
                return BadRequest("Material number or emission data cannot be null or empty.");
            }

           
            var updatedRecord = _service.UpdateByEmission(materialNo, emissionDataRecord);
            return Ok(updatedRecord);
        }

    }
}