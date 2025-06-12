using EmissionDataRecordService.Model;
using EmissionDataRecordService.Repository;
using Serilog;

namespace EmissionDataRecordService.Service
{
    public class EmissionDataService: IEmissionDataService
    {
        private readonly IEmissionRepositoryInterface _repository;

        private readonly ILogger<EmissionDataService> _logger;
        public EmissionDataService(IEmissionRepositoryInterface repository, ILogger<EmissionDataService> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public List<EmissionDataRecord> GetAllEmissionDataRecords()
        {
            _logger.LogInformation("Fetching all emission data records.");
            return _repository.GetAllEmissions();
        }
        public List<EmissionDataRecord> GetByMaterialNo(string materialNo)
        {
            if (string.IsNullOrEmpty(materialNo))
            {
                _logger.LogError("Material number cannot be null or empty.");
                throw new ArgumentException("Material number cannot be null or empty.", nameof(materialNo));
            }         
            _logger.LogInformation($"Fetching emission data records for material number: {materialNo}");
            return _repository.GetMaterialNo(materialNo);
        }
        public List<EmissionDataRecord> GetByCountryCode(string isoCode)
        {
            if (isoCode.Length!=2)
            {
                _logger.LogError("ISO country code cannot be null.");
                throw new ArgumentException("ISO country code cannot be null or empty.", nameof(isoCode));
            }
            _logger.LogInformation($"Fetching emission data records for country code: {isoCode}");
            return _repository.GetCountryCode(isoCode);
        }
        public EmissionDataRecord AddNewEmission(EmissionDataRecord emissionDataRecord)
        {
            if (emissionDataRecord == null)
            {
                _logger.LogError("Emission data record cannot be null.");
                throw new ArgumentNullException(nameof(emissionDataRecord), "Emission data record cannot be null.");
            }
            _logger.LogInformation("Adding new emission data record.");
            return _repository.AddEmission(emissionDataRecord);
        }
        public EmissionDataRecord UpdateByEmission(string materialNo, EmissionDataRecord emissionDataRecord)
        {
            if (string.IsNullOrEmpty(materialNo))
            {
                _logger.LogError("Material number cannot be null or empty.");
                throw new ArgumentException("Material number cannot be null or empty.", nameof(materialNo));
            }
            if (emissionDataRecord == null)
            {
                _logger.LogError("Emission data record cannot be null.");
                throw new ArgumentNullException(nameof(emissionDataRecord), "Emission data record cannot be null.");
            }
            _logger.LogInformation($"Updating emission data record for material number: {materialNo}");
            return _repository.UpdateEmission(materialNo, emissionDataRecord);
        }

       
    }
}
