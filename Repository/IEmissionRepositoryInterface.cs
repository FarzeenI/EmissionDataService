using EmissionDataRecordService.Model;

namespace EmissionDataRecordService.Repository
{
    public interface IEmissionRepositoryInterface
    {
      List<EmissionDataRecord> GetAllEmissions();
      List<EmissionDataRecord> GetMaterialNo(string materialNo);
      List<EmissionDataRecord> GetCountryCode(string isoCode);
      EmissionDataRecord AddEmission(EmissionDataRecord emissionDataRecord);
      EmissionDataRecord UpdateEmission(string materialNo, EmissionDataRecord emissionDataRecord);
    }
}
